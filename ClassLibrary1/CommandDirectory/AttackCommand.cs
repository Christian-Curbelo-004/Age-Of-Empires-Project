using ClassLibrary1.CivilizationDirectory;


namespace CommandDirectory;

public class AttackCommand : IPlayerCommand
{
    private readonly IMapService _mapService;

    public AttackCommand(IMapService mapService)
    {
        _mapService = mapService;
    }

    public async Task <string> ExecuteAsync(string entityType, string destination, Player player)
    {
        return await _mapService.AttackAsync(entityType, destination);
    }
}
