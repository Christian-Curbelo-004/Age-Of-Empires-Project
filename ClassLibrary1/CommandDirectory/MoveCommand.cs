namespace CommandDirectory;

public class MoveCommand : ICommand
{
    private readonly IMapService _mapService;

    public MoveCommand(IMapService mapService)
    {
        _mapService = mapService;
    }

    public async Task ExecuteAsync(string entityType, string destination)
    {
        await _mapService.MoveEntityAsync(entityType, destination);
    }
}