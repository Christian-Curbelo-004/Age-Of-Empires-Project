using ClassLibrary1.BuildingsDirectory;

namespace ClassLibrary1.MapDirectory
{
    public class KnowingCell
    {
        private readonly Map map;

        public KnowingCell(Map map)
        {
            this.map = map;
        }

        public int CheckPopulation(int ownerId)
        {
            int maxCapacity = 0;
            string message = $"El jugador {ownerId} tiene {maxCapacity} de capacidad";
            foreach (var cell in map.Cells)
            {
                if (!cell.IsOccupied || cell.Entity == null)
                    continue;

                var entity = cell.Entity;
                if (entity is ICapacity capacityEntity && entity.OwnerId == ownerId)
                {
                    maxCapacity += capacityEntity.Capacity;
                }
            }

            return maxCapacity;
        }
    }
}