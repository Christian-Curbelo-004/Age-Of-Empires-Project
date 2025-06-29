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

    public async Task<string> AttackAsync(string entityType, string destination)
    {
        await _mover.MoveEntityAsync(entityType, destination);
        var (x, y) = _mover.ParseCoords(destination);
        var cell = _map.Cells[x, y];

        var attacker = _map.GetAllCells()
            .FirstOrDefault(c => c.EntityType == entityType)?.Entity as ICharacter;

        if (attacker == null)
        {
            return $"'{entityType}' no puede atacar.";
        }

        if (cell.Entity is ICharacter target)
        {
            await Task.Delay(2000);
            int damage = attacker.Attack(target);
            return $"{entityType} atacó a personaje.\nDaño infligido: {damage}. Vida restante: {target.Life}";
        }
        else if (cell.Entity is Buildings building)
        {
            await Task.Delay(2000);
            building.Endurence -= attacker.AttackValue;
            return $"{entityType} atacó edificio.\nDaño a edificio: {attacker.AttackValue}. Resistencia restante: {building.Endurence}";
        }
        else
        {
            return $"No hay objetivo para atacar en ({x},{y}).";
        }
    }
}