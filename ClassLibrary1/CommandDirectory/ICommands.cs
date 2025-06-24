namespace CommandDirectory;
public interface ICommand
{
    Task ExecuteAsync(string obj, string parameter);
}