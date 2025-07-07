using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.LogicDirectory;
using ClassLibrary1.QuaryDirectory;


namespace ClassLibrary1.CommandDirectory
{
    public class BuildingsConstructor
    {
        private readonly Map _map;
        private readonly BuildCreateCore _buildCreateCore;

        public BuildingsConstructor(Map map, BuildCreateCore buildCreateCore)
        {
            _map = map;
            _buildCreateCore = buildCreateCore;
        }

        public async Task<string> ConstructAsync(string buildingType, string destination, Player player)
        {
            var (x, y) = ParseCoords(destination);
            if (!_map.IsWithinBounds(x, y))
                return $"Coordenadas ({x},{y}) fuera del mapa.";

            var cell = _map.GetCell(x, y);
            if (cell.IsOccupied)
                return $"La celda ({x},{y}) ya está ocupada.";
            Buildings? built = buildingType.ToLower() switch
            {
                "archercenter" => await _buildCreateCore.BuildArcherCenterAtAsync(x, y, player.Id),
                "civiccenter" => await _buildCreateCore.BuildCivicCenterAtAsync(x, y, player.Id),
                "infantrycenter" => await _buildCreateCore.BuildInfanteryCenterAtAsync(x, y, player.Id),
                "chivarlycenter" => await _buildCreateCore.BuildChivarlyCenterAtAsync(x, y, player.Id),
                "home" => await _buildCreateCore.BuildHomeAtAsync(x, y, player.Id),
                "golddeposit" => await _buildCreateCore.BuildGoldDepositAtAsync(x, y, player.Id),
                "stonedeposit" => await _buildCreateCore.BuildStoneDepositAtAsync(x, y, player.Id),
                "wooddeposit" => await _buildCreateCore.BuildWoodDepositAtAsync(x, y, player.Id),
                "windmill" => await _buildCreateCore.BuildWindMillAtAsync(x, y, player.Id),
                "RaiderCenter" => await _buildCreateCore.BuildRaiderCenterAtAsync(x,y,player.Id),
                "PaladinCenter" => await _buildCreateCore.BuildPaladinCenterAtAsync(x,y,player.Id),
                "CenturiesCenter" => await _buildCreateCore.BuildCenturiesCenterAtAsync(x,y,player.Id),
                _ => null
            };

            if (built == null)
                return $"No se pudo construir '{buildingType}': recursos insuficientes o tipo desconocido.";
            cell.Entities.Add(built);
            if (built is IResourceDeposit deposit)
                cell.Resource = deposit;
            
            player.Buildings.Add(built);

            return $"{buildingType} construido correctamente en ({x},{y}) por el jugador {player.Id}.";
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

