using ClassLibrary1.QuaryDirectory;

namespace ClassLibrary1.MapDirectory
{
    public class EntityManager
    {
        private readonly Map _map;

        public EntityManager(Map map)
        {
            _map = map;
        }

        public bool PlaceEntity(int x, int y, IMapEntity entity)
        {
            if (!_map.IsWithinBounds(x, y)) return false;

            var cell = _map.GetCell(x, y);
            if (cell.IsOccupied) return false;

            cell.Entity = entity;
            cell.IsOccupied = true;
            cell.EntityType = entity.GetType().Name;

            if (entity is IResourceDeposit resource)
            {
                cell.Resource = resource;
            }

            return true;
        }
    }
}