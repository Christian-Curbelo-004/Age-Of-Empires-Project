using System;
using System.Collections.Generic;
namespace ClassLibrary1.CivilizationDirectory;

public class Infantery : Soldier,ICharacter
{
    public int Life { get; set; }
    public int AttackValue { get; set; }
    public int DeffenseValue { get; set; }
    public int Speed { get; set; }

    public Infantery() : base(100,14,10,13)
    {
    }
    public void GetCreate(Dictionary<string,int>GetCost)
    {
        GetCost["Oro"] = 5;
        GetCost["Piedra"] = 30;
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
