namespace ClassLibrary1;

//public class DefaultCivilization : Civilization
public class Roman : Civilization
{
    public Roman()
    {
        Units.Add(new Legionary());
        Units.Add(new Archer());

    }
    public override ICharacter PickUnit(string unitName)
    {
        return unitName.ToLower() switch
        {
            "legionary" => new Legionary(),
            "archer" => new Archer(),
            _ => null
        };
    }
}

public class Legionary : ICharacter
{
    public int Life { get; set; }
    public int AttackValue { get; set; }
    public int DeffenseValue { get; set; }

    public Legionary()
    {
        Life = 100;
        AttackValue = 75;
        DeffenseValue = 50;
    }

    public int Attack(ICharacter target)
    {
        return target.RecieveAttack(AttackValue);
    }

    public int RecieveAttack(int damage)
    {
        DeffenseValue -= damage;
        return Life;
    }
}

public class Archer : ICharacter
{
    public int Life { get; set; }
    public int AttackValue { get; set; }

    public Archer()
    {
        Life = 100;
        AttackValue = 45;
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

public class Templaries : Civilization
{
    public Templaries()
    {
        Units.Add(new Monk());
        Units.Add(new Paladin());
    }
    public override ICharacter PickUnit(string unitName)
    {
        return unitName.ToLower() switch
        {
            "Monk" => new Monk(),
            "Paladin" => new Paladin(),
            _ => null
        };
    }

    public class Monk : ICharacter
    {
        public int Life { get; set; }
        public int AttackValue { get; set; }
        public int DeffenseValue { get; set; }
        public int HealValue { get; set; }

        public Monk()
        {
            Life = 100;
            AttackValue = 60;
            DeffenseValue = 45;
            HealValue = 50;
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

        public int Heal(ICharacter ally)
        {
            ally.Life = Math.Min(ally.Life + HealValue, 100);
            return ally.Life;
        }
    }

    public class Paladin : ICharacter
    {
        public int Life { get; set; }
        public int AttackValue { get; set; }
        public int DeffenseValue {get; set;}


        public Paladin()
        {
            Life = 100;
            AttackValue = 47;
            DeffenseValue = 30;
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
    } 
    
}

public class Viking : Civilization
{
    public Viking()
    {
        Units.Add(new Berserk());
        Units.Add(new Raider());
    }

    public override ICharacter PickUnit(string unitName)
    {
        return unitName.ToLower() switch
        {
            "Berserk" => new Berserk(),
            "Raider" => new Raider(),
            _ => null
        };
    }

    public class Berserk : ICharacter
    {
        public int Life { get; set; }
        public int AttackValue { get; set; }
        public int DeffenseValue { get; set; }

        public Berserk()
        {
            Life = 100;
            AttackValue = 130;
            DeffenseValue = 22;
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
    }

    public class Raider : ICharacter
    {
        public int Life { get; set; }
        public int AttackValue { get; set; }
        public int DeffenseValue { get; set; }


        public Raider()
        {
            Life = 100;
            AttackValue = 22;
            DeffenseValue = 15;
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


    }
}


// clase vikingos


