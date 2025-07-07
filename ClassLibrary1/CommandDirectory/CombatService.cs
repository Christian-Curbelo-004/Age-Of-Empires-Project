using System;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.MapDirectory;
using CommandDirectory;

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
        // Mover primero el atacante al destino
        await _mover.MoveEntityAsync(entityType, destination);

        var (x, y) = _mover.ParseCoords(destination);
        var cell = _map.Cells[x, y];

        // Buscar al atacante en todo el mapa (sensible a mayúsculas)
        var attacker = _map.GetAllCells()
            .SelectMany(c => c.Entities)
            .FirstOrDefault(e => e.GetType().Name.Equals(entityType, StringComparison.OrdinalIgnoreCase)) as ICharacter;

        if (attacker == null)
            return $"'{entityType}' no puede atacar.";

        // Buscar enemigo (unidades) que no sea el atacante y que tenga distinto OwnerId
        var targetCharacter = cell.Entities
            .OfType<ICharacter>()
            .FirstOrDefault(e => e != attacker && e.OwnerId != attacker.OwnerId);

        if (targetCharacter != null)
        {
            await Task.Delay(2000);

            float advantage = CombatAdvantages.GetAddvantage(attacker, targetCharacter);
            int rawDamage = attacker.AttackValue;
            int totalDamage = (int)(rawDamage * advantage);

            targetCharacter.Life -= totalDamage;

            if (targetCharacter is IMapEntity entityTarget)
            {
                if (targetCharacter.Life <= 0)
                {
                    cell.Entities.Remove(entityTarget); // Elimina del mapa si murió
                    return $"{entityType} mató al personaje. Vida restante: 0";
                }
                else if (targetCharacter.Life < 10)
                {
                    entityTarget.Symbol = "!"; // Símbolo de herido
                }
            }

            return $"{entityType} atacó a personaje.\nDaño infligido: {totalDamage}. Vida restante: {targetCharacter.Life}";
        }

        // Buscar edificio enemigo en la celda
        var targetBuilding = cell.Entities
            .OfType<Buildings>()
            .FirstOrDefault(b => b.OwnerId != attacker.OwnerId);

        if (targetBuilding != null)
        {
            await Task.Delay(2000);
            targetBuilding.Endurence -= attacker.AttackValue;

            if (targetBuilding.Endurence <= 0)
            {
                cell.Entities.Remove(targetBuilding); // Elimina del mapa si destruido
                return $"{entityType} destruyó el edificio.";
            }
            else if (targetBuilding.Endurence < 20)
            {
                targetBuilding.Symbol = "%"; // Símbolo de edificio dañado
            }

            return $"{entityType} atacó edificio.\nDaño a edificio: {attacker.AttackValue}. Resistencia restante: {targetBuilding.Endurence}";
        }

        return $"No hay objetivo enemigo para atacar en ({x},{y}).";
    }
}