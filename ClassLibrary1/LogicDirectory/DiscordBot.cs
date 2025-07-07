using Discord;
using Discord.WebSocket;
using Discord.Commands;
using ClassLibrary1;
using ClassLibrary1.FacadeDirectory;
using ClassLibrary1.MapDirectory;
using ClassLibrary1.CommandDirectory;
using ClassLibrary1.Bonus;
using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.LogicDirectory;
using CommandDirectory;
using IMapEntity = ClassLibrary1.MapDirectory.IMapEntity;

public class DiscordBot
{
    private DiscordSocketClient _client;
    private CommandProcessor _commandProcessor;

    private GameFacade _gameFacade;
    private Map _map;
    private ShowScreen _showScreen;
    private MapService _mapService;
    private Player _player;
    private VerificarPartidaPerdida _verificarPartida;
    private readonly SaveGame _gameState = new SaveGame();

    public async Task StartAsync()
    {
        _gameFacade = new GameFacade();
        _map = _gameFacade.GenerateMap();
        _gameFacade.InitializePlayer(_map);
        _player = _gameFacade.PlayerOne;
        _showScreen = new ShowScreen(_map, _player);
        _mapService = new MapService(_map);
        _verificarPartida = new VerificarPartidaPerdida(_gameFacade, _map);

        var commands = new Dictionary<string, IGameCommand>
        {
            { "chop", new ChopCommand(_mapService) },
            { "mine", new MineCommand(_mapService) },
            { "gather", new GatherFoodCommand(_mapService) },
            { "move", new MoveCommand(_mapService) },
            { "attack", new AttackCommand(_mapService) },
            { "create", new CreateTroopCommand(_map) }
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

        string input = message.Content.Substring(1).Trim().ToLower();

        if (input == "map")
        {
            await SendMapInMultipleSectors(message.Channel);
            return;
        }

        if (input.StartsWith("save "))
        {
            var name = input.Substring(5).Trim();
            var context = new CommandContext(_client, message as SocketUserMessage);
            await SaveGame(context, name);
            return;
        }

        if (input.StartsWith("load "))
        {
            var name = input.Substring(5).Trim();
            var context = new CommandContext(_client, message as SocketUserMessage);
            await LoadGame(context, name);
            return;
        }

        if (input == "saves")
        {
            var context = new CommandContext(_client, message as SocketUserMessage);
            await SavedGames(context);
            return;
        }

        string response = await _commandProcessor.ProcessCommand(input);
        await message.Channel.SendMessageAsync(response);

        string screen = _showScreen.Screen();
        await message.Channel.SendMessageAsync($"```\n{screen}\n```");
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

    public async Task<string> BuildCommand()
    {
        var buildCommand = new BuildCommand(_mapService, _player);
        return await buildCommand.ExecuteAsync("Farm", "10");
    }
    
    private int ownerId = 0;
    public Task GenerateFarmCommand(Map map)
    {
        _gameFacade.GenerateFarm(map, 0, 1, ownerId);
        return Task.CompletedTask;
    }

    public Task GenerateForestCommand(Map map)
    {
        _gameFacade.GenerateForest(map, 1, 2, ownerId);
        return Task.CompletedTask;
    }

    public Task GenerateStoneMineCommand(Map map)
    {
        _gameFacade.GenerateStoneMine(map, 3, 4, ownerId);
        return Task.CompletedTask;
    }

    public Task GenerateGoldMineCommand(Map map)
    {
        _gameFacade.GenerateGoldMine(map, 5, 6, ownerId);
        return Task.CompletedTask;
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


