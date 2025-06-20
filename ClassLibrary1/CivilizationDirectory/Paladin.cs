using System.Collections.Generic;
using System;
using GameResourceType = GameModels.GameResourceType;
namespace ClassLibrary1.CivilizationDirectory;


public class Paladin : Soldier, ICharacter 
{
    public override  int Life { get; set; }
    public override int AttackValue { get; set; }
    public override int DeffenseValue { get; set; }
    public override int Speed { get; set; }
    public Dictionary<GameResourceType, int> ConstructionCost { get;  set; } = new ();

    public Paladin() : base(100, 25,  40,9) 
    {
    }
    public void GetCreate(Dictionary<string,int>getCost)
    {
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

    public int BoostDeffense(int damage)
    {
        DeffenseValue += 15;
        return BoostDeffense(damage);
    }

}