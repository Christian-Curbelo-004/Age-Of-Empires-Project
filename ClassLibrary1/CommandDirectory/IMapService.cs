namespace CommandDirectory;
using ClassLibrary1;
public interface IMapService
{
    Task <string> MoveEntityAsync(string entityType, string destination);
    Task<string>ChopAsync(string entityType, string destination);
    Task<string> MineAsync(string entityType, string destination);
    Task <string>AttackAsync(string entityType, string destination);
    Task<string> BuildAsync(string buildingType, string destination, Player player);
}