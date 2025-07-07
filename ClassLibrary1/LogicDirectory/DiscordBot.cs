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
using ClassLibrary1.DepositDirectory;
using ClassLibrary1.LogicDirectory;
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
    private Quary _quary; // Declarado pero no inicializado (cuidado)
    private VerificarPartidaPerdida _verificarPartida;
    private readonly SaveGame _gameState = new SaveGame();

    public async Task StartAsync()
    {
        _gameFacade = new GameFacade();
        _map = _gameFacade.GenerateMap();
        _gameFacade.InitializePlayer(_map);
        _player = _gameFacade.PlayerOne;
        _showScreen = new ShowScreen(_map, _player, _quary);

        // Ejemplo de recursos en el mapa
        var inventory = new ResourceInventory();
        var woodDeposit = new WoodDeposit(100, 0, "WoodDeposit", 500, _player.Id, inventory);
        var goldDeposit = new GoldDeposit(100, 0, "GoldDeposit", 500, _player.Id, inventory);
        var stoneDeposit = new StoneDeposit(100, 0, "StoneDeposit", 500, _player.Id, inventory);
        var windMill = new WindMill(100, 0, "WindMill", 500, _player.Id, inventory);

        _map.PlaceEntity(woodDeposit, 11, 11);
        _map.PlaceEntity(goldDeposit, 12, 11);
        _map.PlaceEntity(stoneDeposit, 13, 11);
        _map.PlaceEntity(windMill, 14, 11);

        _mapService = new MapService(_map);

        _verificarPartida = new VerificarPartidaPerdida(_gameFacade, _map);

        // Inicializa las civilizaciones si es necesario
        _civilization = null; // O asigna la civilización correspondiente

        var commands = new Dictionary<string, IGameCommand>
        {
            { "chop", new ChopCommand(_mapService) },
            { "mine", new MineCommand(_mapService) },
            { "gather", new GatherFoodCommand(_mapService) },
            { "move", new MoveCommand(_mapService) },
            { "attack", new AttackCommand(_mapService) },
            { "create", new CreateTroopCommand(_map, _civilization) },
            { "build", new BuildCommand(_mapService, _player) }
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
        if (!message.Content.StartsWith("!")) return;

        string input = message.Content.Substring(1).Trim();
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0) return;

        string command = parts[0].ToLower();

        if (command == "map")
        {
            await SendMapInMultipleSectors(message.Channel);
            return;
        }

        if (command == "save")
        {
            if (parts.Length < 2)
            {
                await message.Channel.SendMessageAsync(
                    "Debes especificar el nombre para guardar la partida. Ejemplo: !save partida1");
                return;
            }

            var name = parts[1];
            var context = new CommandContext(_client, message as SocketUserMessage);
            await SaveGame(context, name);
            return;
        }

        if (command == "load")
        {
            if (parts.Length < 2)
            {
                await message.Channel.SendMessageAsync(
                    "Debes especificar el nombre de la partida a cargar. Ejemplo: !load partida1");
                return;
            }

            var name = parts[1];
            var context = new CommandContext(_client, message as SocketUserMessage);
            await LoadGame(context, name);
            return;
        }

        if (command == "saves")
        {
            var context = new CommandContext(_client, message as SocketUserMessage);
            await SavedGames(context);
            return;
        }

        if (command == "build")
        {
            if (parts.Length < 3)
            {
                await message.Channel.SendMessageAsync(
                    "Uso correcto: !build <BuildingType> <x,y> (Ejemplo: !build CivicCenter 10,10)");
                return;
            }

            string buildingType = parts[1];
            string coords = parts[2];
            string response =
                await _commandProcessor.ProcessCommand($"{command} {buildingType} {coords}".ToLower());
            await message.Channel.SendMessageAsync(response);
            await SendScreenAsync(message.Channel);
            return;
        }

        string responseGeneral = await _commandProcessor.ProcessCommand(input.ToLower());
        await message.Channel.SendMessageAsync(responseGeneral);

        await SendScreenAsync(message.Channel);

        _verificarPartida.Verificar();
        if (_verificarPartida.PartidaTerminada)
        {
            await message.Channel.SendMessageAsync(
                "Partida terminó porque uno de los dos se quedó sin centro cívico");
        }
    }

    private async Task SendScreenAsync(ISocketMessageChannel channel)
    {
        string screen = _showScreen.Screen();
        await channel.SendMessageAsync($"```\n{screen}\n```");
    }

    private async Task SendMapInMultipleSectors(ISocketMessageChannel channel)
    {
        PrintMap printMap = new PrintMap(_map);
        int sectorWidth = 25;
        int sectorHeight = 20;

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