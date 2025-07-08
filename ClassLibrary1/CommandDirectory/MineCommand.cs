namespace CommandDirectory;


public class MineCommand : IPlayerCommand
{
    private readonly IMapService _mapService;

    public MineCommand(IMapService mapService)
    {
        _mapService = mapService;
    }

    public async Task<string> ExecuteAsync(string entityType, string destination, Player player)
    {
        return await _mapService.MineAsync(entityType, destination, player);
    }
}
