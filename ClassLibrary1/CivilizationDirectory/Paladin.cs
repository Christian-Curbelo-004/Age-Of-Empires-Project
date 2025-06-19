using System.Collections.Generic;
using System;

namespace ClassLibrary1;
    


public class Paladin : Soldier, ICharacter 
{
    public int Life { get; set; }
    public int AttackValue { get; set; }
    public int DeffenseValue { get; set; }
    public int Speed { get; set; }


    public Paladin() : base(100, 25,  40,9) 
    {
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

    public int BoosDeffense(int damage)
    {
        DeffenseValue += 15;
        return BoosDeffense(damage);
    }

}