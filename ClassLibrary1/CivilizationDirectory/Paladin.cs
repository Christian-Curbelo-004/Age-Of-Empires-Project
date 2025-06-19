using System.Collections.Generic;
using System;
using GameResourceType = GameModels.GameResourceType;
namespace ClassLibrary1;
    


public class Paladin : Soldier, ICharacter 
{
    public int Life { get; set; }
    public int AttackValue { get; set; }
    public int DeffenseValue { get; set; }
    public int Speed { get; set; }
    public Dictionary<GameResourceType, int> ConstructionCost { get;  set; } = new ();

    public Paladin() : base(100, 25,  40,9) 
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
        DeffenseValue -= damage;
        return DeffenseValue;
    }

    public int BoosDeffense(int damage)
    {
        DeffenseValue += 15;
        return BoosDeffense(damage);
    }

}