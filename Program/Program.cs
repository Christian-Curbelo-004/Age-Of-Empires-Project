using Discord;
using Discord.WebSocket;
using ClassLibrary1.MapDirectory;       
using ClassLibrary1.FacadeDirectory;
using ClassLibrary1.CommandDirectory;

namespace ClassLibrary1
{
    internal class Program
    {
        private readonly ResourceHarvester _harvester;
        private DiscordSocketClient? _client;
        private readonly BuildingsConstructor _builder;

        static Task Main(string[] args) => new Program().MainAsync();

        private async Task MainAsync()
        {
            GameFacade gameFacade = new GameFacade();
            Map map = gameFacade.GenerateMap();
            gameFacade.InitializePlayer(map);
            ShowScreen showScreen = new ShowScreen(map, gameFacade.PlayerOne);
            string estado = showScreen.Screen();
            Console.WriteLine(estado);
            
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
            Console.WriteLine(log);
            return Task.CompletedTask;
        }

        public Task<string> ChopAsync(string entityType, string destination, SocketMessage message)
        {
            if (message.Author.IsBot)
                if (message.Content == "Talar")
                    return _harvester.ChopAsync(entityType, destination);
                return _harvester.MineAsync(entityType, destination);
        }

        
        private Task ReadyAsync()
        {
            if (_client != null)
                Console.WriteLine($"Conectado como -> {_client.CurrentUser}");
            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(SocketMessage message)
        {
            if (message.Author.IsBot) return;
            if (message.Content == "!ping")
                await message.Channel.SendMessageAsync("Pong!");
        }

        public Task<string> BuildAsync(string buildingType, string destination, Player player)
        {
            var result = _builder.Construct(buildingType, destination, player);
            return Task.FromResult(result);
            
        }
    }
}

