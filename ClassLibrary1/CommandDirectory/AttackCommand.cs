using ClassLibrary1.CivilizationDirectory;
using CreateBuildings;
namespace CommandDirectory;

public class AttackCommand : ICommand
{
    private readonly IMapService _mapService;

    public AttackCommand(IMapService mapService)
    {
        _mapService = mapService;
    }

    public async Task ExecuteAsync(string entityType, string destination)
    {
        await _mapService.AttackAsync(entityType, destination);
    }
}
