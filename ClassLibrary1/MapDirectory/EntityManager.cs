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
            if (!_map.IsWithinBounds(x, y))
                return false;

            var cell = _map.GetCell(x, y);
            cell.Entities.Add(entity);
            if (entity is IResourceDeposit resource)
            {
                cell.Resource = resource;
            }
            
            entity.Position = (x, y);

            return true;
        }
    }
}