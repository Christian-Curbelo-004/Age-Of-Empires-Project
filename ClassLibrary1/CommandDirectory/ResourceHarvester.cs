using ClassLibrary1.DepositDirectory;
using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;
using CommandDirectory;
using System.Linq;

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
        var cell = _map.GetCell(x, y);

        var forest = cell.Entities.OfType<Forest>().FirstOrDefault();

        if (forest != null)
        {
            await Task.Delay(8000);
            int collected = forest.GetResources(1);
            forest.CurrentAmount = Math.Max(0, forest.CurrentAmount - collected);

            var woodDeposit = _map.GetEntities<WoodDeposit>()
                .FirstOrDefault(d => d.OwnerId == forest.OwnerId);

            woodDeposit?.StoreWood(collected);

            return $"{entityType} taló en ({x},{y}) y recolectó {collected} madera. Restante: {forest.CurrentAmount}";
        }

        return $"No hay bosque en ({x},{y}).";
    }

    public async Task<string> GatherFoodAsync(string entityType, string destination)
    {
        await _mover.MoveEntityAsync(entityType, destination);
        var (x, y) = _mover.ParseCoords(destination);

        if (!_map.IsWithinBounds(x, y))
            return $"Coordenadas ({x},{y}) fuera del mapa.";

        var cell = _map.Cells[x, y];
        var farm = cell.Entities.OfType<Farm>().FirstOrDefault();

        if (farm != null)
        {
            await Task.Delay(8000);
            int collected = farm.GetResources(1);
            farm.CurrentAmount = Math.Max(0, farm.CurrentAmount - collected);

            var windMill = _map.GetEntities<WindMill>()
                .FirstOrDefault(d => d.OwnerId == farm.OwnerId);

            windMill?.StoreFood(collected);

            return $"{entityType} recolectó comida en ({x},{y}) y consiguió {collected}. Restante: {farm.CurrentAmount}";
        }

        return $"No hay granja en ({x},{y}).";
    }

    public async Task<string> MineAsync(string entityType, string destination)
    {
        await _mover.MoveEntityAsync(entityType, destination);
        var (x, y) = _mover.ParseCoords(destination);

        if (!_map.IsWithinBounds(x, y))
            return $"Coordenadas ({x},{y}) fuera del mapa.";

        var cell = _map.Cells[x, y];

        var goldMine = cell.Entities.OfType<GoldMine>().FirstOrDefault();
        if (goldMine != null)
        {
            await Task.Delay(8000);
            int collected = goldMine.GetResources(1);
            goldMine.CurrentAmount = Math.Max(0, goldMine.CurrentAmount - collected);

            var goldDeposit = _map.GetEntities<GoldDeposit>()
                .FirstOrDefault(d => d.OwnerId == goldMine.OwnerId);

            goldDeposit?.StoreGold(collected);

            return $"{entityType} minó oro en ({x},{y}) y recolectó {collected}. Restante: {goldMine.CurrentAmount}";
        }

        var stoneMine = cell.Entities.OfType<StoneMine>().FirstOrDefault();
        if (stoneMine != null)
        {
            await Task.Delay(8000);
            int collected = stoneMine.GetResources(1);
            stoneMine.CurrentAmount = Math.Max(0, stoneMine.CurrentAmount - collected);

            var stoneDeposit = _map.GetEntities<StoneDeposit>()
                .FirstOrDefault(d => d.OwnerId == stoneMine.OwnerId);

            stoneDeposit?.StoreStone(collected);

            return $"{entityType} minó piedra en ({x},{y}) y recolectó {collected}. Restante: {stoneMine.CurrentAmount}";
        }

        return $"No hay mina válida en ({x},{y}).";
    }
}