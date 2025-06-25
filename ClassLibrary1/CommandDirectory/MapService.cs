using ClassLibrary1.MapDirectory;
using CommandDirectory;
using EntityMover = CommandDirectory.EntityMover;

public class MapService : IMapService
{
    private readonly EntityMover _mover;
    private readonly ResourceHarvester _harvester;
    private readonly CombatService _combat;

    public MapService(Map map)
    {
        _mover = new EntityMover(map);
        _harvester = new ResourceHarvester(map, _mover);
        _combat = new CombatService(map, _mover);
    }

    public Task MoveEntityAsync(string entityType, string destination) =>
        _mover.MoveEntityAsync(entityType, destination);

    public Task ChopAsync(string entityType, string destination) =>
        _harvester.ChopAsync(entityType, destination);

    public Task MineAsync(string entityType, string destination) =>
        _harvester.MineAsync(entityType, destination);

    public Task AttackAsync(string entityType, string destination) =>
        _combat.AttackAsync(entityType, destination);
}