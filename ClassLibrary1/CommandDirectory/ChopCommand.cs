namespace CommandDirectory;
public class ChopCommand : IPlayerCommand
{
    private readonly IMapService _mapService;

    public ChopCommand(IMapService mapService)
    {
        _mapService = mapService;
    }

    public async Task <string> ExecuteAsync(string entityType, string destination, Player player)
    {
        return await _mapService.ChopAsync(entityType, destination);
    }
}