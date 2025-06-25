
namespace ClassLibrary1.MapDirectory
{
    public class Map
    {
        private readonly int _height;
        private readonly int _length;
        private readonly List<IMapEntity> _entities = new();

        public Cell[,] Cells { get; }

        private const int MinDimension = 0;
        private const int MaxDimension = 100;

        public Map(int height, int length)
        {
            _height = Math.Clamp(height, MinDimension, MaxDimension);
            _length = Math.Clamp(length, MinDimension, MaxDimension);
            Cells = new Cell[_length, _height];

            for (int x = 0; x < _length; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    Cells[x, y] = new Cell(x, y);
                }
            }
        }

        public bool IsWithinBounds(int x, int y) =>
            x >= 0 && x < _length && y >= 0 && y < _height;

        public Cell GetCell(int x, int y)
        {
            if (!IsWithinBounds(x, y))
                throw new ArgumentOutOfRangeException($"({x},{y}) está fuera del mapa.");
            return Cells[x, y];
        }

        public bool PlaceEntity(IMapEntity entity, int x, int y)
        {
            if (!IsWithinBounds(x, y))
            {
                Console.WriteLine($" Posición ({x},{y}) fuera del mapa.");
                return false;
            }

            var cell = Cells[x, y];

            if (cell.Entity != null)
            {
                Console.WriteLine($"La celda ({x},{y}) ya está ocupada por otra entidad ({cell.Entity.GetType().Name}).");
                return false;
            }

            entity.Position = (x, y);
            _entities.Add(entity);
            cell.Entity = entity;
            cell.IsOccupied = true;
            cell.EntityType = entity.GetType().Name;

            return true;
        }
        public void RemoveEntity(IMapEntity entity)
        {
            var (x, y) = entity.Position;
            if (IsWithinBounds(x, y) && Cells[x, y].Entity == entity)
            {
                Cells[x, y].Entity = null;
                Cells[x, y].IsOccupied = false;
                Cells[x, y].EntityType = null;
            }
            _entities.Remove(entity);
        }

        public List<T> GetEntities<T>() where T : IMapEntity
        {
            return _entities.OfType<T>().ToList();
        }

        public IEnumerable<Cell> GetAllCells()
        {
            for (int x = 0; x < _length; x++)
                for (int y = 0; y < _height; y++)
                    yield return Cells[x, y];
        }
        
    }
}