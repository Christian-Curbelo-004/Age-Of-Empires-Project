// using System;
//using System.Collections.Generic;
//using GameResourceType = GameModels.GameResourceType;

using GameModels;

namespace ClassLibrary1.CivilizationDirectory;

public class Chivarly : Soldier                                 //ICharacter
{
    
    public Chivarly() : base(100, 20, 15,20)
    {
    }
    public override int Attack(ICharacter target)
    {
        return target.RecieveAttack(AttackValue);
    }

    public override int RecieveAttack(int damage)
    {
        Life -= damage;
        return Life;
    }
}