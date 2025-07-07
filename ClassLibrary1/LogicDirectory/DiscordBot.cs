using Discord;
using Discord.WebSocket;
using Discord.Commands;
using ClassLibrary1;
using ClassLibrary1.FacadeDirectory;
using ClassLibrary1.MapDirectory;
using ClassLibrary1.CommandDirectory;
using ClassLibrary1.Bonus;
using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.LogicDirectory;
using ClassLibrary1.UnitsDirectory;
using CommandDirectory;
using IMapEntity = ClassLibrary1.MapDirectory.IMapEntity;

public class DiscordBot
{
    private DiscordSocketClient _client;
    private CommandProcessor _commandProcessor;

    private GameFacade _gameFacade;
    private Map _map;
    private Civilization _civilization;
    private ShowScreen _showScreen;
    private MapService _mapService;
    private Player _player;
    private Quary _quary;
    private VerificarPartidaPerdida _verificarPartida;
    private readonly SaveGame _gameState = new SaveGame();
    private Player _playerOne;
    private Player _playerTwo;
    private Player _currentPlayer;
    private GameInitializer _gameInitializer;

    public async Task StartAsync()
    {
        _gameFacade = new GameFacade();
        _map = _gameFacade.GenerateMap();
        _gameFacade.InitializePlayers();
        _gameInitializer = new GameInitializer(_gameFacade, _map);
        _gameInitializer.SetupGame();
        

        _playerOne = _gameFacade.PlayerOne;
        _playerTwo = _gameFacade.PlayerTwo;
        _player = _playerOne;
        _currentPlayer = _playerOne;

        Random random = new Random();
        MapUtils.ColocarRecursosEnEsquina(_map, 0, 0, 40, 40, 70, random, _playerOne.Id);
        MapUtils.ColocarRecursosEnEsquina(_map, _map.Width - 25, _map.Height - 25, 40, 40, 70, random, _playerTwo.Id);

        var villagersCollector = new Villagers(100, 2, _player.Id, 3);
        _quary = new Farm(x: 5, y: 5, initialFood: 100, extractionRate: 10, collectionValue: 5, ownerId: _player.Id, collector: villagersCollector);

        _showScreen = new ShowScreen(_map, _player, _quary);
        _verificarPartida = new VerificarPartidaPerdida(_map);
        _verificarPartida.Verificar(_playerOne.Id, _playerTwo.Id);

        _civilization = new Roman();
        _civilization.Player = _currentPlayer;

        var player = _civilization.Player;
        var resourceInventory = player.Resources;
        var knowingCell = new KnowingCell(_map);
        var unitAffordable = new UnitAffordable(player.Resources);
        var builCreateCore = new BuildCreateCore(player.Resources);
        _mapService = new MapService(_map,builCreateCore);

        var unitCreateCore = new UnitCreateCore(resourceInventory, _map, player, knowingCell, unitAffordable);

        var commands = new Dictionary<string, IGameCommand>
        {
            { "chop", new ChopCommand(_mapService) },
            { "mine", new MineCommand(_mapService) },
            { "gather", new GatherFoodCommand(_mapService) },
            { "move", new MoveCommand(_mapService) },
            { "attack", new AttackCommand(_mapService) },
            { "create", new CreateTroopCommand(_map, _civilization, unitCreateCore) },
            { "build", new BuildCommand(_mapService) }
        };
        _commandProcessor = new CommandProcessor(commands);

        _client = new DiscordSocketClient(new DiscordSocketConfig
        {
            GatewayIntents = GatewayIntents.Guilds |
                             GatewayIntents.GuildMessages |
                             GatewayIntents.MessageContent
        });

        _client.Log += LogAsync;
        _client.Ready += ReadyAsync;
        _client.MessageReceived += MessageReceivedAsync;

        var token = Environment.GetEnvironmentVariable("DISCORD_TOKEN");
        if (string.IsNullOrWhiteSpace(token))
            throw new Exception("Token de Discord no configurado.");

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        await Task.Delay(-1);
    }

    private void NextTurn()
    {
        _currentPlayer = _currentPlayer == _playerOne ? _playerTwo : _playerOne;
    }

    private Task LogAsync(LogMessage log)
    {
        Console.WriteLine(log.ToString());
        return Task.CompletedTask;
    }

    private Task ReadyAsync()
    {
        Console.WriteLine($"Conectado como {_client.CurrentUser}");
        return Task.CompletedTask;
    }

    private async Task MessageReceivedAsync(SocketMessage message)
    {
        if (message.Author.IsBot) return;
        string input = message.Content.Substring(1).Trim(); // sacás el "!" inicial
        string responseMessage = await _commandProcessor.ProcessCommand(input, _currentPlayer);
        await message.Channel.SendMessageAsync(responseMessage);
        var parts = input.Split(new[] { '+', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0) return;

        string command = parts[0].ToLower();

        switch (command)
        {
            case "map":
                // Para evitar mensajes muy largos, imprimimos el mapa en sectores
                await SendMapInMultipleSectors(message.Channel);
                break;

            case "civilization":
                if (parts.Length < 2)
                {
                    await message.Channel.SendMessageAsync("Uso correcto: !civilization+<CivilizationName> (Ejemplo: !civilization+Roman)");
                    return;
                }
                string civName = parts[1].ToLower();
                switch (civName)
                {
                    case "roman":
                        _civilization = new Roman();
                        break;
                    case "viking":
                        _civilization = new Viking();
                        break;
                    case "templaries":
                        _civilization = new Templaries();
                        break;
                    default:
                        await message.Channel.SendMessageAsync("Tenés que elegir entre: Roman, Viking o Templaries");
                        return;
                }
                _civilization.Player = _playerOne;
                await message.Channel.SendMessageAsync($"Elegiste la civilización: {parts[1]}");
                break;

            case "build":
                if (parts.Length < 3)
                {
                    await message.Channel.SendMessageAsync("Uso correcto: !build+<Entidad>+<x,y> (Ejemplo: !build+home+3,3)");
                    return;
                }
                

                // Mostrar mapa y recursos solo UNA vez
                await SendScreenAsync(message.Channel);

                NextTurn();
                await message.Channel.SendMessageAsync($"Turno de {_currentPlayer}");

                _verificarPartida.Verificar(_playerOne.Id, _playerTwo.Id);
                if (_verificarPartida.PartidaTerminada)
                    await message.Channel.SendMessageAsync("Partida terminó porque uno de los dos se quedó sin centro cívico");

                break;
        }
    }

    private async Task SendScreenAsync(ISocketMessageChannel channel)
    {
        string screen = _showScreen.Screen();
        await channel.SendMessageAsync($"```\n{screen}\n```");
        string resourcemessage = _showScreen.ShowRecolectionResourceMuf();
        await channel.SendMessageAsync($"```\n{resourcemessage}\n```");
    }

    private async Task SendMapInMultipleSectors(ISocketMessageChannel channel)
    {
        var printMap = new PrintMap(_map);
        const int sectorWidth = 25;
        const int sectorHeight = 20;

        int mapWidth = _map.Width;
        int mapHeight = _map.Height;

        int horizontalSectors = (int)Math.Ceiling((double)mapWidth / sectorWidth);
        int verticalSectors = (int)Math.Ceiling((double)mapHeight / sectorHeight);

        for (int v = 0; v < verticalSectors; v++)
        {
            for (int h = 0; h < horizontalSectors; h++)
            {
                int startX = h * sectorWidth;
                int endX = Math.Min(startX + sectorWidth, mapWidth);
                int startY = v * sectorHeight;
                int endY = Math.Min(startY + sectorHeight, mapHeight);

                string sectorMap = printMap.DisplayMapSector(startX, endX, startY, endY);

                await channel.SendMessageAsync(
                    $"**Mapa - Columnas {startX:D2} a {endX - 1:D2}, Filas {startY:D2} a {endY - 1:D2}**\n```\n{sectorMap}\n```");
            }
        }
    }

    public async Task SaveGame(CommandContext context, string name)
    {
        var estado = new GameState
        {
            PlayerName = context.User.Username,
            Resources = new ResourceInventory(),
            Buildings = new List<Buildings>(),
            Units = new List<IMapEntity>(),
            Position = _player.StartingPosition
        };

        _gameState.Save(name, estado);
        await context.Channel.SendMessageAsync($"{name} la partida fue guardada correctamente.");
    }

    public async Task LoadGame(CommandContext context, string name)
    {
        try
        {
            var game = _gameState.Load(name);

            _player.Resources = game.Resources;
            _player.Buildings = game.Buildings;
            _player.Units = game.Units;
            _player.StartingPosition = game.Position;

            await context.Channel.SendMessageAsync($"{name} la partida fue cargada con éxito.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al cargar el juego: {e.Message}");
            await context.Channel.SendMessageAsync("Error al cargar la partida.");
        }
    }

    public async Task SavedGames(CommandContext context)
    {
        var games = _gameState.ListSaves();
        if (games.Count == 0)
        {
            await context.Channel.SendMessageAsync("No hay partidas guardadas.");
            return;
        }

        string list = string.Join("\n", games);
        await context.Channel.SendMessageAsync($"Partidas guardadas:\n{list}");
    }
}
