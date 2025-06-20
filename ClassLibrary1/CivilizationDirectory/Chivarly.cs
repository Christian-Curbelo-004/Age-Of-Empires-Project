using System;
using GameResourceType = GameModels.GameResourceType;
namespace ClassLibrary1.CivilizationDirectory;

public class Chivarly : Soldier, ICharacter
{
    public override  int Life { get; set; }
    public override  int AttackValue { get; set; }
    public override  int DeffenseValue { get; set; }
   // public override int Speed { get; set; }

    public Chivarly() : base(100, 20, 15,20)
    {
    }
    public void GetCreate(Dictionary<string,int>GetCost)
    {
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
}