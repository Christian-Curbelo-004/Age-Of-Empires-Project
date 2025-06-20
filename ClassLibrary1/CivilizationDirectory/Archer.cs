
using GameResourceType = GameModels.GameResourceType;
namespace ClassLibrary1.CivilizationDirectory;

public class Archer : Soldier
{
    public override int Life { get; set; }
    public override int AttackValue { get; set; }
    public override int Speed { get; set; }
    public Dictionary<GameResourceType, int> ConstructionCost { get;  set; } = new ();
    public Archer() : base(100,15, 0,20) // Life, AttackValue y Speed
    {
    }

    public void GetCreate(Dictionary<string, int> GetCost)
    {
    }
    
    public override int Attack(ICharacter target)
    {
        return target.RecieveAttack(AttackValue);
    }

    public override  int RecieveAttack(int damage)
    {
        Life -= damage;
        return Life;
    }

    public string? Run(string direction)
    {
        if (direction.ToLower() == "izquierda" || direction.ToLower() == "derecha" || direction.ToLower() == "sube" ||
            direction.ToLower() == "baja") 
        {
            Speed += 10;
            return direction;
        }
        return null;
    }
}