namespace CommandDirectory;
public interface IGameCommand
{
    Task<string> ExecuteAsync(string obj, string parameter, Player player);
}