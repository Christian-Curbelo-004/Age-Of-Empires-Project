using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.LogicDirectory;
using CreateBuildings;
using GameResourceType = GameModels.GameResourceType;
namespace ClassLibrary1;

public class Villagers : ICharacter, IBuilder, ICollect
{
    public int Life { get; set; }
    public int AttackValue { get; set; }
    public int Speed { get; set; }
    public IWorkTarget CurrentTask { get; set; }
    public bool IsFree { get; set; } = true;
    public Dictionary<GameResourceType, int> ConstructionCost { get;  set; } = new ();
    
    public Villagers(int life, int attackValue)
    {
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
    public bool Build(Buildings target,int builders)
    {
        target.ConstructionTimeLeft = Math.Max(0, target.ConstructionTimeLeft - builders);
        if (target.ConstructionTimeLeft <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Collect(Quary target, int collectors)
    {
        target.CollectionTimeLeft = Math.Max(0, target.CollectionTimeLeft - collectors);
        if (target.CollectionTimeLeft <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
