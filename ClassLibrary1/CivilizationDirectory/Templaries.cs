namespace ClassLibrary1.CivilizationDirectory;

public class Templaries : Civilization
{
    public Templaries()
    {
        Units.Add(new Paladin());
    }

    public override ICharacter PickUnit(string unitName)
    {
        return unitName.ToLower() switch
        {

            "Paladin" => new Paladin(),
            _ => null
        };
    }
}
public class Paladin : ICharacter
{
    public int Life { get; set; }
    public int AttackValue { get; set; }
    public int DeffenseValue { get; set; }


    public Paladin()
    {
        Life = 100;
        AttackValue = 25;
        DeffenseValue = 40;
    }

    public int Attack(ICharacter target)
    {
        return target.RecieveAttack(AttackValue);
    }

    public int RecieveAttack(int damage)
    {
        DeffenseValue -= damage;
        return DeffenseValue;
    }

}

