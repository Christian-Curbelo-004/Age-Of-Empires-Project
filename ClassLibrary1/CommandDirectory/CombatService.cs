using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.MapDirectory;

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
            .SelectMany(c => c.Entities)
            .FirstOrDefault(e => e.GetType().Name == entityType) as ICharacter;

        if (attacker == null)
        {
            return $"'{entityType}' no puede atacar.";
        }

        var targetCharacter = cell.Entities.OfType<ICharacter>().FirstOrDefault();
        if (targetCharacter != null)
        {
            await Task.Delay(2000);
            int damage = attacker.Attack(targetCharacter);
            return $"{entityType} atacó a personaje.\nDaño infligido: {damage}. Vida restante: {targetCharacter.Life}";
        }
        
        var targetBuilding = cell.Entities.OfType<Buildings>().FirstOrDefault();
        if (targetBuilding != null)
        {
            await Task.Delay(2000);
            targetBuilding.Endurence -= attacker.AttackValue;
            return $"{entityType} atacó edificio.\nDaño a edificio: {attacker.AttackValue}. Resistencia restante: {targetBuilding.Endurence}";
        }

        return $"No hay objetivo para atacar en ({x},{y}).";
    }
}