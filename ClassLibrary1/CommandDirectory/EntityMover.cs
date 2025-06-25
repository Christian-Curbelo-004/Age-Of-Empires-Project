using ClassLibrary1.CivilizationDirectory.CharactersDirectory;
using ClassLibrary1.MapDirectory;

namespace CommandDirectory;

public class EntityMover
{
    private readonly Map _map;

    public EntityMover(Map map) => _map = map;

    public async Task MoveEntityAsync(string entityType, string destination)
    {
        var (x, y) = ParseCoords(destination);
        if (!_map.IsWithinBounds(x, y))
        {
            Console.WriteLine($"Posición inválida ({x},{y}).");
            return;
        }

        var cell = _map.GetAllCells().FirstOrDefault(c => c.EntityType == entityType);
        if (cell?.Entity is not IMovable movableEntity)
        {
            Console.WriteLine($"'{entityType}' no es una entidad móvil.");
            return;
        }

        int currentX = cell.PosX, currentY = cell.PosY;

        while (currentX != x || currentY != y)
        {
            int nextX = currentX + Math.Sign(x - currentX);
            int nextY = currentY + Math.Sign(y - currentY);

            if (_map.Cells[nextX, nextY].IsOccupied)
            {
                Console.WriteLine($"Celda ocupada en ({nextX}, {nextY}).");
                break;
            }

            await Task.Delay(1000 / movableEntity.Speed);

            _map.Cells[currentX, currentY].Entity = null;
            _map.Cells[currentX, currentY].IsOccupied = false;
            _map.Cells[currentX, currentY].EntityType = null;

            cell.Entity.Position = (nextX, nextY);
            cell.PosX = nextX;
            cell.PosY = nextY;

            _map.Cells[nextX, nextY].Entity = cell.Entity;
            _map.Cells[nextX, nextY].IsOccupied = true;
            _map.Cells[nextX, nextY].EntityType = entityType;

            currentX = nextX;
            currentY = nextY;
            Console.WriteLine($"{entityType} se movió a ({currentX},{currentY}).");
        }

        if (currentX == x && currentY == y)
            Console.WriteLine($"{entityType} llegó a destino ({x},{y}).");
    }

    public (int x, int y) ParseCoords(string input)
    {
        var parts = input.Split(',');
        if (parts.Length != 2 || !int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
            throw new ArgumentException($"Coordenadas inválidas: {input}");
        return (x, y);
    }
}