using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.DepositDirectory;

namespace ClassLibrary1.LogicDirectory;

public class BuildFactory
{
    private readonly IResourceInventory inventory;
    public static ChivarlyCenter CreateChivarlyCenter()
    {
        return new ChivarlyCenter(100, 0, "Chivarly Center", 0);
    }

    public static CivicCenter CreateCivicCenter()
    {
        return new CivicCenter()
        {
            ActualHealth = 500, ConstructionTime = 0, Endurence = 500, Name = "CivicCenter", OwnerId = 0,
        };
    }
    public static InfanteryCenter CreateInfanteryCenter()
    {
        return new InfanteryCenter(100, 0, "Infantery Center", 0);
    }
    public static ArcherCenter CreateArcherCenter()
    {
        return new ArcherCenter(100, 0, "Archer Center", 0);
    }
    public static PaladinCenter CreatePaladinCenter()
    {
        return new PaladinCenter(150, 0, "Paladin Center", 0);
    }
    public static RaiderCenter CreateRaiderCenter()
    {
        return new RaiderCenter(150, 0, "Raider Center", 0);
    }
    public static CenturiesCenter CreateCenturiesCenter()
    {
        return new CenturiesCenter(150, 0, "Centuries Center", 0);
    }

    public static Home CreateHome()
    {
        return new Home(80, 0, "Home");
    }

    public static GoldDeposit CreateGoldDeposit(ResourceInventory inventory)
    {
        return new GoldDeposit(200, 0, "Gold Deposit", 100,0, inventory);
    }
    public static StoneDeposit CreateStoneDeposit(ResourceInventory inventory)
    {
        return new StoneDeposit(200, 0, "Stone Deposit", 100,0, inventory);
    }
    public static WoodDeposit CreateWoodDeposit(ResourceInventory inventory)
    {
        return new WoodDeposit(200, 0, "Wood Deposit", 100,0, inventory);
    }
    public static WindMill CreateWindMill(ResourceInventory inventory)
    {
        return new WindMill(200, 0, "WindMill", 100,0,inventory);
    }
}