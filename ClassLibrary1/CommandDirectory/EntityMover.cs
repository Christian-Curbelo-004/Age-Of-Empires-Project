using ClassLibrary1.CivilizationDirectory.CharactersDirectory;
using ClassLibrary1.MapDirectory;
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

        var cell = _map.GetAllCells()
            .FirstOrDefault(c => c.Entities.Any(e => e.GetType().Name == entityType));

        if (cell == null)
        {
            messages.Add($"No se encontró ninguna entidad del tipo '{entityType}'.");
            return messages;
        }

        var entity = cell.Entities.FirstOrDefault(e => e.GetType().Name == entityType);

        if (entity is not IMovable movableEntity)
        {
            messages.Add($"'{entityType}' no es una entidad móvil.");
            return messages;
        }

        int currentX = cell.PosX;
        int currentY = cell.PosY;

        while (currentX != x || currentY != y)
        {
            int nextX = currentX + Math.Sign(x - currentX);
            int nextY = currentY + Math.Sign(y - currentY);

            var destCell = _map.Cells[nextX, nextY];
            await Task.Delay(1000 / movableEntity.Speed);

            cell.Entities.Remove(entity);
            entity.Position = (nextX, nextY);
            destCell.Entities.Add(entity);
            cell = destCell;
            currentX = nextX;
            currentY = nextY;

            messages.Add($"{entityType} se movió a ({currentX},{currentY}).");
        }

        if (currentX == x && currentY == y)
            messages.Add($"{entityType} llegó a destino ({x},{y}).");

        return messages;
    }

    public async Task<List<string>> MoveEntitiesOfTypeAsync(string entityType, int amount, (int x, int y) from, (int x, int y) to)
    {
        var messages = new List<string>();

        if (!_map.IsWithinBounds(from.x, from.y))
        {
            messages.Add($"Posición origen inválida ({from.x},{from.y}).");
            return messages;
        }

        if (!_map.IsWithinBounds(to.x, to.y))
        {
            messages.Add($"Posición destino inválida ({to.x},{to.y}).");
            return messages;
        }

        var originCell = _map.Cells[from.x, from.y];
        var destCell = _map.Cells[to.x, to.y];
        var entitiesToMove = originCell.Entities
            .Where(e => e.GetType().Name == entityType && e is IMovable)
            .Cast<IMovable>()
            .Take(amount)
            .ToList();

        if (entitiesToMove.Count == 0)
        {
            messages.Add($"No se encontraron entidades móviles del tipo '{entityType}' en la celda origen.");
            return messages;
        }

        foreach (var entity in entitiesToMove)
        {
            int currentX = from.x;
            int currentY = from.y;
            IMovable movableEntity = entity;

            while (currentX != to.x || currentY != to.y)
            {
                int nextX = currentX + Math.Sign(to.x - currentX);
                int nextY = currentY + Math.Sign(to.y - currentY);

                var nextCell = _map.Cells[nextX, nextY];

                // Sin límite de entidades por celda

                await Task.Delay(1000 / movableEntity.Speed);

                originCell.Entities.Remove(entity);
                entity.Position = (nextX, nextY);
                nextCell.Entities.Add(entity);

                currentX = nextX;
                currentY = nextY;

                messages.Add($"{entityType} movido a ({currentX},{currentY}).");
            }

            messages.Add($"{entityType} llegó a destino ({to.x},{to.y}).");
        }

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
