using ClassLibrary1.CivilizationDirectory.CharactersDirectory;
using ClassLibrary1.MapDirectory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandDirectory;

public class EntityMover
{
    private readonly Map _map;

    public EntityMover(Map map) => _map = map;

    public async Task<List<string>> MoveEntityAsync(string entityType, string destination)
    {
        var messages = new List<string>();
        var (x, y) = ParseCoords(destination);

        if (!_map.IsWithinBounds(x, y))
        {
            messages.Add($"Posición inválida ({x},{y}).");
            return messages;
        }

        var cell = _map.GetAllCells().FirstOrDefault(c => c.EntityType == entityType);
        if (cell?.Entity is not IMovable movableEntity)
        {
            messages.Add($"'{entityType}' no es una entidad móvil.");
            return messages;
        }

        int currentX = cell.PosX, currentY = cell.PosY;

        while (currentX != x || currentY != y)
        {
            int nextX = currentX + Math.Sign(x - currentX);
            int nextY = currentY + Math.Sign(y - currentY);

            if (_map.Cells[nextX, nextY].IsOccupied)
            {
                messages.Add($"Celda ocupada en ({nextX}, {nextY}).");
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
            messages.Add($"{entityType} se movió a ({currentX},{currentY}).");
        }

        if (currentX == x && currentY == y)
            messages.Add($"{entityType} llegó a destino ({x},{y}).");

        return messages;
    }

    public (int x, int y) ParseCoords(string input)
    {
        var parts = input.Split(',');
        if (parts.Length != 2 || !int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
            throw new ArgumentException($"Coordenadas inválidas: {input}");
        return (x, y);
    }
}
