using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.DepositDirectory;
using ClassLibrary1.MapDirectory;
using CreateBuildings;

namespace ClassLibrary1.CommandDirectory;

public class BuildingsConstructor
{
    private readonly Map _map;
    public BuildingsConstructor(Map map)
    {
        _map = map;
    }

    public void Construct(string buildingType, string destination, int ownerId)
    {
        var (x, y) = ParseCoords(destination);
        if (!_map.IsWithinBounds(x, y))
        {
            Console.WriteLine($"Coordenadas ({x},{y}) fuera del mapa.");
            return;
        }
        var cell = _map.GetCell(x, y);
        if (cell.IsOccupied)
        {
            Console.WriteLine($"La celda ({x},{y}) ya está ocupada, no se puede construir.");
            return;
        }
        Buildings newBuilding = buildingType.ToLower() switch
        {
            "home" => new Home(20, 10, "Home"),
            "civiccenter" => new CivicCenter(),
            "archercenter" => new ArcherCenter(20, 13, "ArcherCenter", 1),
            "chivarlycenter" => new ChivarlyCenter(20, 10, "ChivarlyCenter", 1),
            "InfantryCenter" => new InfanteryCenter(20, 10, "InfantryCenter", 1),
            "golddeposit" => new GoldDeposit(20, 10, "GoldDeposit", 300, 1),
            "stonedeposit" => new StoneDeposit(20, 10, "StoneDeposit", 300,1),
            "windmill" => new WindMill(20, 10, "WindMill", 300,1),
            "wooddeposit" => new WoodDeposit(20, 10, "WoodDeposit", 300, 1),
            _ => null
        };
        if (newBuilding  == null)
        {
            Console.WriteLine($"Tipo de edificio '{buildingType}' no reconocido.");
            return;
        }
        _map.Cells[x, y].Entity = newBuilding;
        _map.Cells[x, y].IsOccupied = true;
        _map.Cells[x, y].EntityType = buildingType;
        Console.WriteLine($"{buildingType} construido en ({x},{y}) por el jugador {ownerId}.");
    }

    private (int x, int y) ParseCoords(string input)
    {
        var parts = input.Split(',');
        if (parts.Length != 2 || !int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
            throw new ArgumentException($"Coordenadas inválidas: {input}");
        return (x, y);
    }
}

