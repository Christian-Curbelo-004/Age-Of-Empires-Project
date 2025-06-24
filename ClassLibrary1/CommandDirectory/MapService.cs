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
        var coords = ParseCoords(destination);
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
            if (currentX < coords.x) currentX++;
            else if (currentX > coords.x) currentX--;

            if (currentY < coords.y) currentY++;
            else if (currentY > coords.y) currentY--;

            int moveTime = 1000 / movableEntity.Speed;
            await Task.Delay(moveTime);

            _map.Cells[cell.PosX, cell.PosY].IsOccupied = false;
            _map.Cells[cell.PosX, cell.PosY].EntityType = null;

            cell.PosX = currentX;
            cell.PosY = currentY;

            _map.Cells[currentX, currentY].IsOccupied = true;
            _map.Cells[currentX, currentY].EntityType = entityType;
        }

        Console.WriteLine($"{entityType} se movió a ({coords.x},{coords.y}).");
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
            int collected = forest.GetResources();
            Console.WriteLine($"{entityType} recolectó {collected} madera.");
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
            int collected = goldMine.GetResources();
            Console.WriteLine($"{entityType} recolectó {collected} oro.");
        }
        else if (cell.Resource is StoneMine stoneMine)
        {
            Console.WriteLine($"{entityType} minando piedra en ({x},{y})...");
            await Task.Delay(3000);
            int collected = stoneMine.GetResources();
            Console.WriteLine($"{entityType} recolectó {collected} piedra.");
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
        return (int.Parse(parts[0]), int.Parse(parts[1]));
    }
}