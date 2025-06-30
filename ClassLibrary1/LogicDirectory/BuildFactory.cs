using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.DepositDirectory;

namespace ClassLibrary1.LogicDirectory;

public class BuildFactory
{
    // Falta CivicCenter
    public static ChivarlyCenter CreateChivarlyCenter()
    {
        return new ChivarlyCenter(30, 0, "Chivarly Center", 0);
    }
    public static InfanteryCenter CreateInfanteryCenter()
    {
        return new InfanteryCenter(30, 0, "Chivarly Center", 0);
    }
    public static ArcherCenter CreateArcherCenter()
    {
        return new ArcherCenter(30, 0, "Chivarly Center", 0);
    }
    public static PaladinCenter CreatePaladinCenter()
    {
        return new PaladinCenter(30, 0, "Chivarly Center", 0);
    }
    public static RaiderCenter CreateRaiderCenter()
    {
        return new RaiderCenter(30, 0, "Chivarly Center", 0);
    }
    public static CenturiesCenter CreateCenturiesCenter()
    {
        return new CenturiesCenter(30, 0, "Chivarly Center", 0);
    }

    public static Home CreateHome()
    {
        return new Home(30, 0, "home");
    }

    public static GoldDeposit CreateGoldDeposit()
    {
        return new GoldDeposit(30, 0, "Gold Deposit", 100,0);
    }
    public static StoneDeposit CreateStoneDeposit()
    {
        return new StoneDeposit(30, 0, "Stone Deposit", 100,0);
    }
    public static WoodDeposit CreateWoodDeposit()
    {
        return new WoodDeposit(30, 0, "Wood Deposit", 100,0);
    }
    public static WindMill CreateWindMill()
    {
        return new WindMill(30, 0, "WindMill", 100,0);
    }
}