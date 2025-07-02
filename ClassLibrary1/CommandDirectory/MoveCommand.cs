namespace CommandDirectory;

public class MoveCommand : IGameCommand
{
    private readonly IMapService _mapService;

    public MoveCommand(IMapService mapService)
    {
        _mapService = mapService;
    }

    public async Task <string> ExecuteAsync(string entityType, string destination)
    {
        return await _mapService.MoveEntityAsync(entityType, destination);
    }
}