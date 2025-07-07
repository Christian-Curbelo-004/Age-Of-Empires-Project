using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.UnitsDirectory;


namespace ClassLibrary1.LogicDirectory;

public class UnitFactory
{
    public static Archer CreateArcher()
    {
        return new Archer
        {
            Life = 100,
            AttackValue = 20,
            DeffenseValue = 10,
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
    public static Centuries CreateCenturies()
    {
        return new Centuries()
        {
            Life = 100,
            AttackValue = 40,
            DeffenseValue = 12,
            Speed = 12,
        };
    }
    public static Raider CreateRaider()
    {
        return new Raider()
        {
            Life = 100,
            AttackValue = 33,
            DeffenseValue = 25,
            Speed = 15,
        };
    }
    public static Paladin CreatePaladin()
    {
        return new Paladin()
        {
            Life = 100,
            AttackValue = 25,
            DeffenseValue = 40,
            Speed = 9,
        };
    }

    public static GameUnit CreateVillagers()
    {
        return new Villagers(100, 5, 0, 5);
    }
}