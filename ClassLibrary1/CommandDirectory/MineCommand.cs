namespace CommandDirectory;
using ClassLibrary1.QuaryDirectory;

public class MineCommand : ICommand
{
    private readonly IMapService _mapService;

    public MineCommand(IMapService mapService)
    {
        _mapService = mapService;
    }

    public async Task ExecuteAsync(string entityType, string destination)
    {
        await _mapService.MineAsync(entityType, destination);
    }
}
