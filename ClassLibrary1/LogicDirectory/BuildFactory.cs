using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.DepositDirectory;

namespace ClassLibrary1.LogicDirectory;

public class BuildFactory
{
    private readonly ResourceInventory inventory;
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

    public static GoldDeposit CreateGoldDeposit(ResourceInventory inventory)
    {
        return new GoldDeposit(30, 0, "Gold Deposit", 100,0, inventory);
    }
    public static StoneDeposit CreateStoneDeposit(ResourceInventory inventory)
    {
        return new StoneDeposit(30, 0, "Stone Deposit", 100,0, inventory);
    }
    public static WoodDeposit CreateWoodDeposit(ResourceInventory inventory)
    {
        return new WoodDeposit(30, 0, "Wood Deposit", 100,0, inventory);
    }
    public static WindMill CreateWindMill(ResourceInventory inventory)
    {
        return new WindMill(30, 0, "WindMill", 100,0,inventory);
    }
}