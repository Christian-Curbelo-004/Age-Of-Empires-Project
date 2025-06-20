//using System;
//using System.Collections.Generic;
//  using GameResourceType = GameModels.GameResourceType;
namespace ClassLibrary1.CivilizationDirectory;

public class Infantery : Soldier                                                //ICharacter
{

    public Infantery() : base(100,14,10,13)
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
