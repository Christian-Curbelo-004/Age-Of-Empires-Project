using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;
using CommandDirectory;

public class ResourceHarvester
{
    private readonly Map _map;
    private readonly EntityMover _mover;

    public ResourceHarvester(Map map, EntityMover mover)
    {
        _map = map;
        _mover = mover;
    }

    public async Task ChopAsync(string entityType, string destination)
    {
        await _mover.MoveEntityAsync(entityType, destination);
        var (x, y) = _mover.ParseCoords(destination);
        var cell = _map.Cells[x, y];

        if (cell.Resource is Forest forest)
        {
            Console.WriteLine($"{entityType} talando en ({x},{y})...");
            await Task.Delay(3000);
            int collected = forest.GetResources(1);
            forest.CurrentAmount = Math.Max(0, forest.CurrentAmount - collected);
            Console.WriteLine($"{entityType} recolectó {collected} madera. Restante: {forest.CurrentAmount}");
        }
        else
        {
            Console.WriteLine($"No hay bosque en ({x},{y}).");
        }
    }

    public async Task MineAsync(string entityType, string destination)
    {
        await _mover.MoveEntityAsync(entityType, destination);
        var (x, y) = _mover.ParseCoords(destination);
        var cell = _map.Cells[x, y];

        if (cell.Resource is GoldMine goldMine)
        {
            Console.WriteLine($"{entityType} minando oro...");
            await Task.Delay(3000);
            int collected = goldMine.GetResources(1);
            goldMine.CurrentAmount = Math.Max(0, goldMine.CurrentAmount - collected);
            Console.WriteLine($"{entityType} recolectó {collected} oro. Restante: {goldMine.CurrentAmount}");
        }
        else if (cell.Resource is StoneMine stoneMine)
        {
            Console.WriteLine($"{entityType} minando piedra...");
            await Task.Delay(3000);
            int collected = stoneMine.GetResources(1);
            stoneMine.CurrentAmount = Math.Max(0, stoneMine.CurrentAmount - collected);
            Console.WriteLine($"{entityType} recolectó {collected} piedra. Restante: {stoneMine.CurrentAmount}");
        }
        else
        {
            Console.WriteLine($"No hay mina válida en ({x},{y}).");
        }
    }
}