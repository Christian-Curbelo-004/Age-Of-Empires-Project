using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.DepositDirectory;
using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;
using CreateBuildings;


namespace ClassLibrary1.CommandDirectory
{
    public class BuildingsConstructor
    {
        private readonly Map _map;

        public BuildingsConstructor(Map map)
        {
            _map = map;
        }

        public string Construct(string buildingType, string destination, Player player)
        {
            var (x, y) = ParseCoords(destination);
            if (!_map.IsWithinBounds(x, y))
            {
                return $"Coordenadas ({x},{y}) fuera del mapa.";
            }

            var cell = _map.GetCell(x, y);

            if (cell.IsOccupied)
            {
                return $"La celda ({x},{y}) ya está ocupada, no se puede construir.";
            }

            var inventory = player.Resources;

            Buildings newBuilding = buildingType.ToLower() switch
            {
                "home" => new Home(20, 10, "Home"),
                "civiccenter" => new CivicCenter(10, 10, "CivicCenter", 1),
                "archercenter" => new ArcherCenter(20, 13, "ArcherCenter", 1),
                "chivarlycenter" => new ChivarlyCenter(20, 10, "ChivarlyCenter", 1),
                "infantrycenter" => new InfanteryCenter(20, 10, "InfantryCenter", 1),
                "golddeposit" => new GoldDeposit(20, 10, "GoldDeposit", 300, 1, inventory),
                "stonedeposit" => new StoneDeposit(20, 10, "StoneDeposit", 300, 1, inventory),
                "windmill" => new WindMill(20, 10, "WindMill", 300, 1, inventory),
                "wooddeposit" => new WoodDeposit(20, 10, "WoodDeposit", 300, 1, inventory),
                _ => null
            };

            if (newBuilding == null)
            {
                return $"Tipo de edificio '{buildingType}' no reconocido.";
            }

            newBuilding.Position = (x, y);
            newBuilding.OwnerId = player.Id;
            cell.Entities.Add(newBuilding);
            player.Buildings.Add(newBuilding);

            if (newBuilding is IResourceDeposit resource)
            {
                cell.Resource = resource;
            }

            return $"{buildingType} construido en ({x},{y}) por el jugador {player.Id}.";
        }

        private (int x, int y) ParseCoords(string input)
        {
            var parts = input.Split(',');
            if (parts.Length != 2 || !int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
                throw new ArgumentException($"Coordenadas inválidas: {input}");
            return (x, y);
        }
    }
}

