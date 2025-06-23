using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.DepositDirectory;
using ClassLibrary1.FacadeDirectory;
using ClassLibrary1.LogicDirectory;
using CreateBuildings;
using GameResourceType = GameModels.GameResourceType;
namespace ClassLibrary1;

public class Villagers : ICharacter
{
    public int Life { get; set; }
    public int AttackValue { get; set; }
    public int Speed { get; set; }
    public IWorkTarget CurrentTask { get; set; }
    public int OwnerId { get; set; }
    public string Name { get; set; }
    public string EntityType => "Villagers";
    public bool IsFree { get; set; } = true;
    public Dictionary<GameResourceType, int> ConstructionCost { get;  set; } = new ();
    
    public Villagers(int life, int attackValue, int ownerId)
    {
        OwnerId= ownerId;
        Life = life;
        AttackValue = attackValue;
    }
    public int Attack(ICharacter target) //cambie el void que devolvia por un int, ya que nos interesa unicamente el valor, el console.writeline va en el program
    {
        //Console.WriteLine("El aldeano ataco al enemigo");
        int DamageDone = target.RecieveAttack(AttackValue);

        return DamageDone;
    }

    public int RecieveAttack(int damage)
    {
        Life -= damage;
        return Life;
        //Console.WriteLine($"El aldeano recibio {damage} de daño");
    }
    public Dictionary<GameResourceType, int> GetCreationCost()
    {
        return new Dictionary<GameResourceType, int>
        {
            {GameResourceType.Stone,100},
            {GameResourceType.Gold, 40},
            {GameResourceType.Food, 150}
        };
    }
}
