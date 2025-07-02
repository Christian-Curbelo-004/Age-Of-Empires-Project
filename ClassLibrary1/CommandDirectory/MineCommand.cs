namespace CommandDirectory;


public class MineCommand : IGameCommand
{
    private readonly IMapService _mapService;

    public MineCommand(IMapService mapService)
    {
        _mapService = mapService;
    }

    public async Task<string> ExecuteAsync(string entityType, string destination)
    {
        return await _mapService.MineAsync(entityType, destination);
    }
}
