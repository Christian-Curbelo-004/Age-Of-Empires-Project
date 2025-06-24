using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.CivilizationDirectory.CharactersDirectory;
using ClassLibrary1.QuaryDirectory;
using ClassLibrary1.MapDirectory;
using CommandDirectory;
using CreateBuildings;

public class MapService : IMapService
{
    private readonly Map _map;

    public MapService(Map map)
    {
        _map = map;
    }

    public async Task MoveEntityAsync(string entityType, string destination)
    {
        (int x, int y) coords;
        try
        {
            coords = ParseCoords(destination);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        if (!_map.IsWithinBounds(coords.x, coords.y))
        {
            Console.WriteLine($"Posición inválida ({coords.x},{coords.y}).");
            return;
        }

        var cell = _map.GetAllCells().FirstOrDefault(c => c.EntityType == entityType);
        if (cell == null)
        {
            Console.WriteLine($"Entidad '{entityType}' no encontrada.");
            return;
        }

        if (!(cell.Entity is IMovable movableEntity))
        {
            Console.WriteLine($"La entidad '{entityType}' no puede moverse.");
            return;
        }

        int currentX = cell.PosX;
        int currentY = cell.PosY;

        while (currentX != coords.x || currentY != coords.y)
        {
            int nextX = currentX;
            int nextY = currentY;

            if (currentX < coords.x) nextX++;
            else if (currentX > coords.x) nextX--;

            if (currentY < coords.y) nextY++;
            else if (currentY > coords.y) nextY--;

            if (_map.Cells[nextX, nextY].IsOccupied)
            {
                Console.WriteLine($"Movimiento bloqueado en ({nextX}, {nextY}), celda ocupada.");
                break;
            }

            int moveTime = 1000 / movableEntity.Speed;
            await Task.Delay(moveTime);

            // Limpiar celda actual
            _map.Cells[currentX, currentY].Entity = null;
            _map.Cells[currentX, currentY].IsOccupied = false;
            _map.Cells[currentX, currentY].EntityType = null;

            // Actualizar posición en la entidad
            cell.Entity.Position = (nextX, nextY);

            // Actualizar posición en la celda
            cell.PosX = nextX;
            cell.PosY = nextY;

            currentX = nextX;
            currentY = nextY;

            _map.Cells[currentX, currentY].Entity = cell.Entity;
            _map.Cells[currentX, currentY].IsOccupied = true;
            _map.Cells[currentX, currentY].EntityType = entityType;

            Console.WriteLine($"{entityType} se movió a ({currentX},{currentY}).");
        }

        if (currentX == coords.x && currentY == coords.y)
            Console.WriteLine($"{entityType} llegó a destino ({coords.x},{coords.y}).");
    }

    public async Task ChopAsync(string entityType, string destination)
    {
        await MoveEntityAsync(entityType, destination);
        var (x, y) = ParseCoords(destination);
        var cell = _map.Cells[x, y];

        if (cell.Resource is Forest forest)
        {
            Console.WriteLine($"{entityType} talando en ({x},{y})...");
            await Task.Delay(3000);
            int collected = forest.GetResources(1); // suponiendo 1 trabajador
            forest.CurrentAmount -= collected;
            if (forest.CurrentAmount < 0) forest.CurrentAmount = 0;
            Console.WriteLine($"{entityType} recolectó {collected} madera. Madera restante: {forest.CurrentAmount}");
        }
        else
        {
            Console.WriteLine($"No hay bosque en ({x},{y}).");
        }
    }

    public async Task MineAsync(string entityType, string destination)
    {
        await MoveEntityAsync(entityType, destination);
        var (x, y) = ParseCoords(destination);
        var cell = _map.Cells[x, y];

        if (cell.Resource is GoldMine goldMine)
        {
            Console.WriteLine($"{entityType} minando oro en ({x},{y})...");
            await Task.Delay(3000);
            int collected = goldMine.GetResources(1);
            goldMine.CurrentAmount -= collected;
            if (goldMine.CurrentAmount < 0) goldMine.CurrentAmount = 0;
            Console.WriteLine($"{entityType} recolectó {collected} oro. Oro restante: {goldMine.CurrentAmount}");
        }
        else if (cell.Resource is StoneMine stoneMine)
        {
            Console.WriteLine($"{entityType} minando piedra en ({x},{y})...");
            await Task.Delay(3000);
            int collected = stoneMine.GetResources(1);
            stoneMine.CurrentAmount -= collected;
            if (stoneMine.CurrentAmount < 0) stoneMine.CurrentAmount = 0;
            Console.WriteLine($"{entityType} recolectó {collected} piedra. Piedra restante: {stoneMine.CurrentAmount}");
        }
        else
        {
            Console.WriteLine($"No hay mina válida en ({x},{y}).");
        }
    }

    public async Task AttackAsync(string entityType, string destination)
    {
        await MoveEntityAsync(entityType, destination);
        var (x, y) = ParseCoords(destination);
        var cell = _map.Cells[x, y];

        var attacker = _map.GetAllCells()
            .FirstOrDefault(c => c.EntityType == entityType)?.Entity as ICharacter;

        if (attacker == null)
        {
            Console.WriteLine($"'{entityType}' no puede atacar.");
            return;
        }

        if (cell.Entity is ICharacter target)
        {
            Console.WriteLine($"{entityType} atacando en ({x},{y})...");
            await Task.Delay(2000);
            int damage = attacker.Attack(target);
            Console.WriteLine($"Daño infligido: {damage}. Vida restante: {target.Life}.");
        }
        else if (cell.Entity is Buildings building)
        {
            Console.WriteLine($"{entityType} atacando estructura en ({x},{y})...");
            await Task.Delay(2000);
            building.Endurence -= attacker.AttackValue;
            Console.WriteLine($"Daño a estructura: {attacker.AttackValue}. Resistencia restante: {building.Endurence}.");
        }
        else
        {
            Console.WriteLine($"No hay objetivo para atacar en ({x},{y}).");
        }
    }

    private (int x, int y) ParseCoords(string input)
    {
        var parts = input.Split(',');
        if (parts.Length != 2
            || !int.TryParse(parts[0], out int x)
            || !int.TryParse(parts[1], out int y))
        {
            throw new ArgumentException($"Coordenadas inválidas: {input}");
        }
        return (x, y);
    }
}