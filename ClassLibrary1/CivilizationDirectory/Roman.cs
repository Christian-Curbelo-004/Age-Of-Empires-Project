using System;
using System.Collections.Generic;
using ClassLibrary1;

namespace Civilizations;

public class Roman : Civilization
{
    public Roman()
    {
        Units.Add(new Archer());
    }

    public override ICharacter PickUnit(string unitName)
    {
        return unitName.ToLower() switch
        {
            "Archer" => new Archer(),
            _ => null,
        };
    }
}

public class Archer : ICharacter
{
    public int Life { get; set; }
    public int AttackValue { get; set; }

    public Archer()
    {
        Life = 100;
        AttackValue = 15;
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