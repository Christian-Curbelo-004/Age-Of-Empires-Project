namespace CommandDirectory;
using ClassLibrary1;
public interface IMapService
{
    Task MoveEntityAsync(string entityType, string destination);
    Task ChopAsync(string entityType, string destination);
    Task MineAsync(string entityType, string destination);
    Task AttackAsync(string entityType, string destination);
}