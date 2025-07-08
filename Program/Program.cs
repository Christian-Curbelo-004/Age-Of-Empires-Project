class Program
{
    static async Task Main(string[] args)
    {
        var bot = new DiscordBot();
        await bot.StartAsync();
    }
}