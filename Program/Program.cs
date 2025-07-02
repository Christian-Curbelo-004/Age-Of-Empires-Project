using Discord;
using Discord.WebSocket;
using ClassLibrary1.MapDirectory;
using ClassLibrary1.FacadeDirectory;
using ClassLibrary1.CommandDirectory;
using CommandDirectory;

namespace ClassLibrary1
{
    internal class Program
    {
        private DiscordSocketClient? _client;
        private CommandProcessor _commandProcessor;

        static Task Main(string[] args) => new Program().MainAsync();

        private async Task MainAsync()
        {
            // 🎮 SETUP DEL JUEGO
            GameFacade gameFacade = new GameFacade();
            Map map = gameFacade.GenerateMap();
            gameFacade.InitializePlayer(map);
            ShowScreen showScreen = new ShowScreen(map, gameFacade.PlayerOne);
            var mapService = new MapService(map);
            var player = gameFacade.PlayerOne;
            var commands = new Dictionary<string, IGameCommand>
            {
                { "chop", new ChopCommand(mapService) },
                { "mine", new MineCommand(mapService) },
                { "move", new MoveCommand(mapService) },
                { "attack", new AttackCommand(mapService) }
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
            Console.WriteLine($"Conectado como {_client?.CurrentUser}");
            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(SocketMessage message)
        {
            if (message.Author.IsBot) return;

            if (message.Content.StartsWith("!"))
            {
                string input = message.Content.Substring(1); 
                string response = await _commandProcessor.ProcessCommand(input);
                await message.Channel.SendMessageAsync(response);
            }
        }
    }
}