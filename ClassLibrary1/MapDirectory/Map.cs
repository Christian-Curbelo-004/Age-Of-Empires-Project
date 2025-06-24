

namespace ClassLibrary1.MapDirectory
{
    public class Map
    {
        private int _height;
        private int _length;
        public Cell[,] Cells { get; }

        private const int MinDimension = 0;
        private const int MaxDimension = 100;

        // ✅ Lista para almacenar las entidades en el mapa
        private readonly List<IMapEntity> _entities = new();
        public object map;

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
                throw new ArgumentOutOfRangeException($"({x},{y}) fuera del mapa.");
            return Cells[x, y];
        }

        // ✅ Método para colocar entidades en el mapa
        public void PlaceEntity(IMapEntity entity, int x, int y)
        {
            if (!IsWithinBounds(x, y))
                throw new ArgumentOutOfRangeException($"({x},{y}) fuera del mapa.");

            entity.Position = (x, y);
            _entities.Add(entity);
        }

        // ✅ Método para obtener entidades por tipo
        public List<T> GetEntities<T>() where T : IMapEntity
        {
            return _entities.OfType<T>().ToList();
        }
    }
}