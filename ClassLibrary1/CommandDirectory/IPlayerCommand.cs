namespace CommandDirectory
{
    public interface IPlayerCommand : IGameCommand
    {
        Task<string> ExecuteAsync(string obj, string parameter, Player player);
    }
}