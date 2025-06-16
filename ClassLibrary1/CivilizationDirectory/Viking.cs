namespace ClassLibrary1.CivilizationDirectory;

public class Viking : Civilization
{
    public Viking()
    {
        Units.Add(new Raider());
    }
    public override ICharacter PickUnit(string unitName)
    {
        return unitName.ToLower() switch
        { 
            "Raider" => new Raider(),
            _ => null
        };
    }
    public class Raider : ICharacter
    {
        public int Life { get; set; }
        public int AttackValue { get; set; }
        public int DeffenseValue { get; set; }


        public Raider()
        {
            Life = 100;
            AttackValue = 33;
            DeffenseValue = 25;
        }
        public void GetCreate(Dictionary<string,int>GetCost)
        {
            GetCost["Oro"] = 5;
            GetCost["Piedra"] = 40;
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
}
