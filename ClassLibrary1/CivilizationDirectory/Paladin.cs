using System.Collections.Generic;
using System;

namespace ClassLibrary1;
    


public class Paladin : ICharacter
{
    public int Life { get; set; }
    public int AttackValue { get; set; }
    public int DeffenseValue { get; set; }
    public int Speed { get; set; }


    public  Paladin()
    {
        Life = 100;
        AttackValue = 25;
        DeffenseValue = 40;
        Speed = 9;
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