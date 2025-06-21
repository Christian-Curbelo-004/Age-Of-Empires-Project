namespace ClassLibrary1.CivilizationDirectory;

public class Peleas
{
    public List<string> Combates(ICharacter attacker, ICharacter target)
    {
        List<string> historialCombate = new List<string>();

        int daño = attacker.Attack(target);
        historialCombate.Add($"{attacker.GetType().Name} atacó a {target.GetType().Name} y le pegó {daño}");
        if (target.Life <= 0)
        {
            historialCombate.Add($"{target.GetType().Name} murió");
        }
        else
        {
            historialCombate.Add($"{target.GetType().Name} tiene {target.Life} de vida");
        }

        return historialCombate;
    }
}