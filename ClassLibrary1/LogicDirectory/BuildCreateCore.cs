using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.DepositDirectory;
using ClassLibrary1.UnitsDirectory;

namespace ClassLibrary1.LogicDirectory;

public class BuildCreateCore
{
    private readonly ResourceInventory inventory;
    private readonly UnitAffordable unitAffordable;

    public BuildCreateCore(ResourceInventory resourceInventory)
    {
        this.inventory = resourceInventory;
        this.unitAffordable = new UnitAffordable(resourceInventory);
    }

    public async Task ReturnArcherCenter(ArcherCenter archerCenter)
    {
        if (unitAffordable.CanAfford(CreationCost.ArcherCenter))
        {
            BuildFactory.CreateArcherCenter();
            inventory.Spend(CreationCost.ArcherCenter);
            await ConstructionTimeManager.BuildAsync(archerCenter, 2000);
            archerCenter.IsConstructed = true;
        }
    }

    public async Task ReturnCivicCenter(CivicCenter civicCenter)
    {
        if (unitAffordable.CanAfford(CreationCost.CivicCenter))
        {
            BuildFactory.CreateCivicCenter();
            inventory.Spend(CreationCost.CivicCenter);
            await ConstructionTimeManager.BuildAsync(civicCenter, 3000);
            civicCenter.IsConstructed = true;
        }
    }
    public async Task ReturnInfanteryCenter(InfanteryCenter infanteryCenter)
    {
        if (unitAffordable.CanAfford(CreationCost.InfanteryCenter))
        {
            BuildFactory.CreateInfanteryCenter();
            inventory.Spend(CreationCost.InfanteryCenter);
            await ConstructionTimeManager.BuildAsync(infanteryCenter, 2000);
            infanteryCenter.IsConstructed = true;
        }
    }

    public async Task ReturnChivarlyCenter(ChivarlyCenter chivarlyCenter)
    {
        if (unitAffordable.CanAfford(CreationCost.ChivarlyCenter))
        {
            BuildFactory.CreateChivarlyCenter();
            inventory.Spend(CreationCost.ChivarlyCenter);
            await ConstructionTimeManager.BuildAsync(chivarlyCenter, 2000);
            chivarlyCenter.IsConstructed = true;
        }
    }

    public async Task ReturnRaiderCenter(RaiderCenter raiderCenter)
    {
        if (unitAffordable.CanAfford(CreationCost.RaiderCenter))
        {
            BuildFactory.CreateRaiderCenter();
            inventory.Spend(CreationCost.RaiderCenter);
            await ConstructionTimeManager.BuildAsync(raiderCenter, 2000);
            raiderCenter.IsConstructed = true;
        }
    }

    public async Task ReturnPaladinCenter(PaladinCenter paladinCenter)
    {
        if (unitAffordable.CanAfford(CreationCost.PaladinCenter))
        {
            BuildFactory.CreatePaladinCenter();
            inventory.Spend(CreationCost.PaladinCenter);
            await ConstructionTimeManager.BuildAsync(paladinCenter, 2000);
            paladinCenter.IsConstructed = true;
        }
    }

    public async Task ReturnCenturiesCenter(CenturiesCenter centuriesCenter)
    {
        if (unitAffordable.CanAfford(CreationCost.CenturiesCenter))
        {
            BuildFactory.CreateCenturiesCenter();
            inventory.Spend(CreationCost.CenturiesCenter);
            await ConstructionTimeManager.BuildAsync(centuriesCenter, 2000);
            centuriesCenter.IsConstructed = true;
        }
    }

    public async Task ReturnGoldDeposit(GoldDeposit goldDeposit)
    {
        if (unitAffordable.CanAfford(CreationCost.GoldDeposit))
        {
            BuildFactory.CreateGoldDeposit(inventory);
            inventory.Spend(CreationCost.GoldDeposit);
            await ConstructionTimeManager.BuildAsync(goldDeposit, 2500);
            goldDeposit.IsConstructed = true;
        }
    }

    public async Task ReturnWoodDeposit(WoodDeposit woodDeposit)
    {
        if (unitAffordable.CanAfford(CreationCost.WoodDeposit))
        {
            BuildFactory.CreateWoodDeposit(inventory);
            inventory.Spend(CreationCost.WoodDeposit);
            await ConstructionTimeManager.BuildAsync(woodDeposit, 2500);
            woodDeposit.IsConstructed = true;
        }
    }

    public async Task ReturnStoneDeposit(StoneDeposit stoneDeposit)
    {
        if (unitAffordable.CanAfford(CreationCost.StoneDeposit))
        {
            BuildFactory.CreateStoneDeposit(inventory);
            inventory.Spend(CreationCost.StoneDeposit);
            await ConstructionTimeManager.BuildAsync(stoneDeposit, 2500);
            stoneDeposit.IsConstructed = true;
        }
    }

    public async Task ReturnWindmill(WindMill windMill)
    {
        if (unitAffordable.CanAfford(CreationCost.WindMill))
        {
            BuildFactory.CreateWindMill(inventory);
            inventory.Spend(CreationCost.WindMill);
            await ConstructionTimeManager.BuildAsync(windMill, 2500);
            windMill.IsConstructed = true;
        }
    }

    public async Task ReturnHome(Home home)
    {
        if (unitAffordable.CanAfford(CreationCost.Home))
        {
            BuildFactory.CreateHome();
            inventory.Spend(CreationCost.Home);
            await ConstructionTimeManager.BuildAsync(home, 1500);
            home.IsConstructed = true;
        }
    }

    public bool VillagersBuilding(Villagers villager, Buildings buildings) // nuevo 
    {
        return villager.Build(buildings);
    }
}