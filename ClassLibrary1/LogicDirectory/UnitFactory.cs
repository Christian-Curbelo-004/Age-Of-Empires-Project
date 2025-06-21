using ClassLibrary1.CivilizationDirectory;
namespace ClassLibrary1.LogicDirectory;

public class UnitFactory
{
    public static Archer CreateArcher()
    {
        return new Archer
        {
            Life = 100,
            AttackValue = 15,
            Speed = 20,
        };
    }

    public static Infantery CreateInfantery()
    {
        return new Infantery()
        {
            Life = 100,
            AttackValue = 14,
            DeffenseValue = 10,
            Speed = 13,
        };
    }

    public static Chivarly CreateChivarly()
    {
        return new Chivarly()
        {
            Life = 100,
            AttackValue = 20,
            DeffenseValue = 15,
            Speed = 20,
        };
    }
}