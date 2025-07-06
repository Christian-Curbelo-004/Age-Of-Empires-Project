
using CommandDirectory;

namespace ClassLibrary1.CommandDirectory
{
    public class CreateTroopCommand : IGameCommand
    {
        private readonly Map _map;

        public CreateTroopCommand(Map map)
        {
            _map = map;
        }

        public async Task<string> ExecuteAsync(string buildingType, string troopType)
        {
            var building = _map.GetEntities<ITrainingBuilding>()
                .FirstOrDefault(b => b.GetType().Name.Equals(buildingType, StringComparison.OrdinalIgnoreCase));

            if (building == null)
                return $"No se encontró un edificio del tipo '{buildingType}'.";

            try
            {
                var troop = building.CreateUnit(troopType);
                _map.AddEntity(troop);
                return $"{troopType} creado en {buildingType} en posición {troop.Position.X},{troop.Position.Y}.";
            }
            catch (Exception ex)
            {
                return $"Error al crear la tropa: {ex.Message}";
            }
        }
    }
}