namespace ClassLibrary1.CivilizationDirectory;
public class Figths  
{
    public List<string> Combats(ICharacter attacker, ICharacter target)
    {
        List<string> historialCombate = new List<string>();

        int damage = attacker.Attack(target);
        historialCombate.Add($"{attacker.GetType().Name} atacó a {target.GetType().Name} y le pegó {damage}");
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