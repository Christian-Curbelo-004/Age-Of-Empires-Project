using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;
using CommandDirectory;
using System.Threading.Tasks;

public class ResourceHarvester
{
    private readonly Map _map;
    private readonly EntityMover _mover;

    public ResourceHarvester(Map map, EntityMover mover)
    {
        _map = map;
        _mover = mover;
    }

    public async Task<string> ChopAsync(string entityType, string destination)
    {
        await _mover.MoveEntityAsync(entityType, destination);
        var (x, y) = _mover.ParseCoords(destination);
        var cell = _map.Cells[x, y];

        if (cell.Resource is Forest forest)
        {
            await Task.Delay(3000);
            int collected = forest.GetResources(1);
            forest.CurrentAmount = Math.Max(0, forest.CurrentAmount - collected);
            return $"{entityType} taló en ({x},{y}) y recolectó {collected} madera. Restante: {forest.CurrentAmount}";
        }
        else
        {
            return $"No hay bosque en ({x},{y}).";
        }
    }

    public async Task<string> MineAsync(string entityType, string destination)
    {
        await _mover.MoveEntityAsync(entityType, destination);
        var (x, y) = _mover.ParseCoords(destination);
        var cell = _map.Cells[x, y];

        if (cell.Resource is GoldMine goldMine)
        {
            await Task.Delay(3000);
            int collected = goldMine.GetResources(1);
            goldMine.CurrentAmount = Math.Max(0, goldMine.CurrentAmount - collected);
            return $"{entityType} minó oro y recolectó {collected}. Restante: {goldMine.CurrentAmount}";
        }
        else if (cell.Resource is StoneMine stoneMine)
        {
            await Task.Delay(3000);
            int collected = stoneMine.GetResources(1);
            stoneMine.CurrentAmount = Math.Max(0, stoneMine.CurrentAmount - collected);
            return $"{entityType} minó piedra y recolectó {collected}. Restante: {stoneMine.CurrentAmount}";
        }
        else
        {
            return $"No hay mina válida en ({x},{y}).";
        }
    }
}
