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
        public int Width => _length; 
        public int Height => _height;  
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
                Console.WriteLine($"Posición ({x},{y}) fuera del mapa.");
                return false;
            }

            var cell = Cells[x, y];
            if (cell.IsOccupied)
            {
                Console.WriteLine($"La celda ({x},{y}) ya está ocupada por otra entidad.");
                return false;
            }

            entity.Position = (x, y);
            _entities.Add(entity);
            cell.Entities.Add(entity);
            return true;
        }

        public void RemoveEntity(IMapEntity entity)
        {
            var (x, y) = entity.Position;
            if (IsWithinBounds(x, y))
            {
                var cell = Cells[x, y];
                if (cell.Entities.Contains(entity))
                {
                    cell.Entities.Remove(entity);
                    _entities.Remove(entity);
                }
            }
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


/*
// Método que intenta colocar la entidad en (x,y), y si está ocupada busca cerca (radio máximo 5)
private bool TryPlaceEntityNearby(Map map, IMapEntity entity, int x, int y, int maxRadius = 5)
{
    // Primero intenta en la posición original
    if (TryPlaceEntity(map, entity, x, y))
        return true;

    // Busca celdas alrededor en expansión de radio
    for (int radius = 1; radius <= maxRadius; radius++)
    {
        for (int dx = -radius; dx <= radius; dx++)
        {
            for (int dy = -radius; dy <= radius; dy++)
            {
                int newX = x + dx;
                int newY = y + dy;
                if (newX == x && newY == y)
                    continue;

                if (newX >= 0 && newY >= 0 && newX < map.Cells.GetLength(0) && newY < map.Cells.GetLength(1))
                {
                    if (TryPlaceEntity(map, entity, newX, newY))
                        return true;
                }
            }
        }
    }

    Console.WriteLine($"No se pudo colocar la entidad cerca de ({x},{y}).");
    return false;
}






// Método que verifica si la celda está libre y coloca la entidad
        private bool TryPlaceEntity(Map map, IMapEntity entity, int x, int y)
        {
            if (x < 0 || y < 0 || x >= map.Cells.GetLength(0) || y >= map.Cells.GetLength(1))
                return false;

            var cell = map.Cells[x, y];
            if (!cell.IsOccupied)
            {
                map.PlaceEntity(entity, x, y);
                return true;
            }
            else
            {
                // Console.WriteLine($"La celda ({x},{y}) ya está ocupada por otra entidad.");
                return false;
            }
        }









public void RecursosEnEsquinas(Map map, int inicialX, int inicialY, int width, int height, int cantidadrecursos)
        {
            int attemptsLimit = cantidadrecursos * 5;
            int placed = 0;
            int attempts = 0;

            while (placed < cantidadrecursos && attempts < attemptsLimit)
            {
                attempts++;
                int x = _random.Next(inicialX, inicialX + width);
                int y = _random.Next(inicialY, inicialY + height);

                int recurso = _random.Next(3);
                IMapEntity entity;

                if (recurso == 0)
                    entity = new Forest(5, 0, 50, 150);
                else if (recurso == 1)
                    entity = new GoldMine(5, 0, 50, 50);
                else
                    entity = new StoneMine(5, 0, 50, 75);

                if (TryPlaceEntityNearby(map, entity, x, y))
                    placed++;
            }

            if (placed < cantidadrecursos)
                Console.WriteLine($"Solo se colocaron {placed} recursos de {cantidadrecursos} solicitados en la zona.");
        }
*/