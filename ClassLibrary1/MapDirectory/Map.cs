using ClassLibrary1;
using ClassLibrary1.MapDirectory;

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
            return false;

        var cell = Cells[x, y];
        if (cell.IsOccupied)
            return false;

        entity.Position = (x, y);
        _entities.Add(entity);
        cell.Entities.Add(entity);
        return true;
    }
    
    public List<T> GetEntities<T>() where T : IMapEntity =>
        _entities.OfType<T>().ToList();

    public IEnumerable<Cell> GetAllCells()
    {
        for (int x = 0; x < _length; x++)
            for (int y = 0; y < _height; y++)
                yield return Cells[x, y];
    }
}