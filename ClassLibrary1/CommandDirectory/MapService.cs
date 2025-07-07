using ClassLibrary1.CommandDirectory;
using ClassLibrary1.DepositDirectory;
using ClassLibrary1.LogicDirectory;
using CommandDirectory;

public class MapService : IMapService
{
    private readonly Map _map;
    private readonly EntityMover _mover;
    private readonly ResourceHarvester _harvester;
    private readonly CombatService _combat;
    private readonly BuildingsConstructor _builder;

    public MapService(Map map)
    {
        _map = map;
        _mover = new EntityMover(map);
        _harvester = new ResourceHarvester(map, _mover);
        _combat = new CombatService(map, _mover);
        _builder = new BuildingsConstructor(map);
    }

    public async Task<string> MoveEntityAsync(string entityType, string destination) =>
        string.Join("\n", await _mover.MoveEntityAsync(entityType, destination));

    public Task<string> ChopAsync(string entityType, string destination) =>
        _harvester.ChopAsync(entityType, destination);

    public Task<string> GatherFoodAsync(string entityType, string destination) =>
        _harvester.GatherFoodAsync(entityType, destination);

    public Task<string> MineAsync(string entityType, string destination) =>
        _harvester.MineAsync(entityType, destination);

    public Task<string> AttackAsync(string entityType, string destination) =>
        _combat.AttackAsync(entityType, destination);

    public Task<string> BuildAsync(string buildingType, string destination, Player player) =>
        Task.FromResult(_builder.Construct(buildingType, destination, player));
}