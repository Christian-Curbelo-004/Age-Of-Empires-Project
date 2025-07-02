using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.DepositDirectory;

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

    public void ReturnArcherCenter(ArcherCenter archerCenter)
    {
        if (unitAffordable.CanAfford(CreationCost.ArcherCenter))
        {
            BuildFactory.CreateArcherCenter();
            inventory.Spend(CreationCost.ArcherCenter);
            archerCenter.IsConstructed = true;
        }
    }

    public void ReturnCivicCenter(CivicCenter civicCenter)
    {
        if (unitAffordable.CanAfford(CreationCost.CivicCenter))
        {
            BuildFactory.CreateCivicCenter();
            inventory.Spend(CreationCost.CivicCenter);
            civicCenter.IsConstructed = true;
        }
    }
    public void ReturnInfanteryCenter(InfanteryCenter infanteryCenter)
    {
        if (unitAffordable.CanAfford(CreationCost.InfanteryCenter))
        {
            BuildFactory.CreateInfanteryCenter();
            inventory.Spend(CreationCost.InfanteryCenter);
            infanteryCenter.IsConstructed = true;
        }
    }

    public void ReturnChivarlyCenter(ChivarlyCenter chivarlyCenter)
    {
        if (unitAffordable.CanAfford(CreationCost.ChivarlyCenter))
        {
            BuildFactory.CreateChivarlyCenter();
            inventory.Spend(CreationCost.ChivarlyCenter);
            chivarlyCenter.IsConstructed = true;
        }
    }

    public void ReturnRaiderCenter(RaiderCenter raiderCenter)
    {
        if (unitAffordable.CanAfford(CreationCost.RaiderCenter))
        {
            BuildFactory.CreateRaiderCenter();
            inventory.Spend(CreationCost.RaiderCenter);
            raiderCenter.IsConstructed = true;
        }
    }

    public void ReturnPaladinCenter(PaladinCenter paladinCenter)
    {
        if (unitAffordable.CanAfford(CreationCost.PaladinCenter))
        {
            BuildFactory.CreatePaladinCenter();
            inventory.Spend(CreationCost.PaladinCenter);
            paladinCenter.IsConstructed = true;
        }
    }

    public void ReturnCenturiesCenter(CenturiesCenter centuriesCenter)
    {
        if (unitAffordable.CanAfford(CreationCost.CenturiesCenter))
        {
            BuildFactory.CreateCenturiesCenter();
            inventory.Spend(CreationCost.CenturiesCenter);
            centuriesCenter.IsConstructed = true;
        }
    }

    public void ReturnGoldDeposit(GoldDeposit goldDeposit)
    {
        if (unitAffordable.CanAfford(CreationCost.GoldDeposit))
        {
            BuildFactory.CreateGoldDeposit(inventory);
            inventory.Spend(CreationCost.GoldDeposit);
            goldDeposit.IsConstructed = true;
        }
    }

    public void ReturnWoodDeposit(WoodDeposit woodDeposit)
    {
        if (unitAffordable.CanAfford(CreationCost.WoodDeposit))
        {
            BuildFactory.CreateWoodDeposit(inventory);
            inventory.Spend(CreationCost.WoodDeposit);
            woodDeposit.IsConstructed = true;
        }
    }

    public void ReturnStoneDeposit(StoneDeposit stoneDeposit)
    {
        if (unitAffordable.CanAfford(CreationCost.StoneDeposit))
        {
            BuildFactory.CreateStoneDeposit(inventory);
            inventory.Spend(CreationCost.StoneDeposit);
            stoneDeposit.IsConstructed = true;
        }
    }

    public void ReturnWindmill(WindMill windMill)
    {
        if (unitAffordable.CanAfford(CreationCost.WindMill))
        {
            BuildFactory.CreateWindMill(inventory);
            inventory.Spend(CreationCost.WindMill);
            windMill.IsConstructed = true;
        }
    }

    public void returnHome(Home home)
    {
        if (unitAffordable.CanAfford(CreationCost.Home))
        {
            BuildFactory.CreateHome();
            inventory.Spend(CreationCost.Home);
            home.IsConstructed = true;
        }
    }
}