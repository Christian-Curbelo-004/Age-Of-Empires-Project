using System;
using GameResourceType = GameModels.GameResourceType;
namespace ClassLibrary1.CivilizationDirectory;

public class Infantery : Soldier,ICharacter
{
    public override int Life { get; set; }
    public override int AttackValue { get; set; }
    public int DeffenseValue { get; set; }
   // public int Speed { get; set; }
    public Dictionary<GameResourceType, int> ConstructionCost { get;  set; } = new ();

    public Infantery() : base(100,14,10,13)
    {
    }
    public void GetCreate(Dictionary<string,int>GetCost)
    {
        ConstructionCost[GameResourceType.Stone] = 100;
        ConstructionCost[GameResourceType.Gold] = 40;
        ConstructionCost[GameResourceType.Wood] = 150;
    }
    public int Attack(ICharacter target)
    {
        return target.RecieveAttack(AttackValue);
    }

    public int RecieveAttack(int damage)
    {
        Life -= damage;
        return Life;
    }

    public string Run(string direction)
    {
        if (direction.ToLower() == "izquierda" || direction.ToLower() == "derecha" || direction.ToLower() == "sube" ||
            direction.ToLower() == "baja") ;
        {
            Speed += 10;
            return direction;
        }
    }
}
