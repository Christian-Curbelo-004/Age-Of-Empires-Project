namespace CommandDirectory;
public class ChopCommand : ICommand
{
    private readonly IMapService _mapService;

    public ChopCommand(IMapService mapService)
    {
        _mapService = mapService;
    }

    public async Task ExecuteAsync(string entityType, string destination)
    {
        await _mapService.ChopAsync(entityType, destination);
    }
}