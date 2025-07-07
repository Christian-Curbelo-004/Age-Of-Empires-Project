using ClassLibrary1.DepositDirectory;
using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;
using CommandDirectory;

public class ResourceHarvester
{
    private readonly Map _map;
    private readonly EntityMover _mover;
    private readonly WoodDeposit _woodDeposit;
    private readonly GoldDeposit _goldDeposit;
    private readonly StoneDeposit _stoneDeposit;
    private readonly WindMill _windMill;

    public ResourceHarvester(Map map, EntityMover mover,
        WoodDeposit woodDeposit,
        GoldDeposit goldDeposit,
        StoneDeposit stoneDeposit,
        WindMill windMill)
    {
        _map = map;
        _mover = mover;
        _woodDeposit = woodDeposit;
        _goldDeposit = goldDeposit;
        _stoneDeposit = stoneDeposit;
        _windMill = windMill;
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
            _woodDeposit.StoreWood(collected);
            return $"{entityType} taló en ({x},{y}) y recolectó {collected} madera. Restante: {forest.CurrentAmount}";
        }
        else
        {
            return $"No hay bosque en ({x},{y}).";
        }
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

            if (_windMill == null)
                return "Error: Molino (depósito de comida) no inicializado.";

            _windMill.StoreFood(collected);
            return
                $"{entityType} recolectó comida en ({x},{y}) y consiguió {collected}. Restante: {farm.CurrentAmount}";
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

            if (_goldDeposit == null)
                return "Error: Depósito de oro no inicializado.";

            _goldDeposit.StoreGold(collected);
            return $"{entityType} minó oro en ({x},{y}) y recolectó {collected}. Restante: {goldMine.CurrentAmount}";
        }

        var stoneMine = cell.Entities.OfType<StoneMine>().FirstOrDefault();
        if (stoneMine != null)
        {
            await Task.Delay(8000);
            int collected = stoneMine.GetResources(1);
            stoneMine.CurrentAmount = Math.Max(0, stoneMine.CurrentAmount - collected);

            if (_stoneDeposit == null)
                return "Error: Depósito de piedra no inicializado.";

            _stoneDeposit.StoreStone(collected);
            return
                $"{entityType} minó piedra en ({x},{y}) y recolectó {collected}. Restante: {stoneMine.CurrentAmount}";
        }

        return $"No hay mina válida en ({x},{y}).";
    }
}