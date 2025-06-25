using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.MapDirectory;
using CreateBuildings;


namespace CommandDirectory;
public class CombatService
{
    private readonly Map _map;
    private readonly EntityMover _mover;

    public CombatService(Map map, EntityMover mover)
    {
        _map = map;
        _mover = mover;
    }

    public async Task AttackAsync(string entityType, string destination)
    {
        await _mover.MoveEntityAsync(entityType, destination);
        var (x, y) = _mover.ParseCoords(destination);
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
            Console.WriteLine($"{entityType} atacando a personaje...");
            await Task.Delay(2000);
            int damage = attacker.Attack(target);
            Console.WriteLine($"Daño infligido: {damage}. Vida restante: {target.Life}");
        }
        else if (cell.Entity is Buildings building)
        {
            Console.WriteLine($"{entityType} atacando edificio...");
            await Task.Delay(2000);
            building.Endurence -= attacker.AttackValue;
            Console.WriteLine($"Daño a edificio: {attacker.AttackValue}. Resistencia restante: {building.Endurence}");
        }
        else
        {
            Console.WriteLine($"No hay objetivo para atacar en ({x},{y}).");
        }
    }
}