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

    public void ReturnArcherCenter()
    {
        if (unitAffordable.CanAfford(CreationCost.ArcherCenter))
        {
            BuildFactory.CreateArcherCenter();
            inventory.Spend(CreationCost.ArcherCenter);
        }
    }
    
    public void ReturnInfanteryCenter()
    {
        if (unitAffordable.CanAfford(CreationCost.InfanteryCenter))
        {
            BuildFactory.CreateInfanteryCenter();
            inventory.Spend(CreationCost.InfanteryCenter);
        }
    }
    
    public void ReturnChivarlyCenter()
    {
        if (unitAffordable.CanAfford(CreationCost.ChivarlyCenter))
        {
            BuildFactory.CreateChivarlyCenter();
            inventory.Spend(CreationCost.ChivarlyCenter);
        }
    }
    
    public void ReturnRaiderCenter()
    {
        if (unitAffordable.CanAfford(CreationCost.RaiderCenter))
        {
            BuildFactory.CreateRaiderCenter();
            inventory.Spend(CreationCost.RaiderCenter);
        }
    }
    
    public void ReturnPaladinCenter()
    {
        if (unitAffordable.CanAfford(CreationCost.PaladinCenter))
        {
            BuildFactory.CreatePaladinCenter();
            inventory.Spend(CreationCost.PaladinCenter);
        }
    }
    
    public void ReturnCenturiesCenter()
    {
        if (unitAffordable.CanAfford(CreationCost.CenturiesCenter))
        {
            BuildFactory.CreateCenturiesCenter();
            inventory.Spend(CreationCost.CenturiesCenter);
        }
    }
    
    public void ReturnGoldDeposit()
    {
        if (unitAffordable.CanAfford(CreationCost.GoldDeposit))
        {
            BuildFactory.CreateGoldDeposit();
            inventory.Spend(CreationCost.GoldDeposit);
        }
    }
    
    public void ReturnWoodDeposit()
    {
        if (unitAffordable.CanAfford(CreationCost.WoodDeposit))
        {
            BuildFactory.CreateWoodDeposit();
            inventory.Spend(CreationCost.WoodDeposit);
        }
    }
    
    public void ReturnStoneDeposit()
    {
        if (unitAffordable.CanAfford(CreationCost.StoneDeposit))
        {
            BuildFactory.CreateStoneDeposit();
            inventory.Spend(CreationCost.StoneDeposit);
        }
    }

    public void ReturnWindmill()
    {
        if (unitAffordable.CanAfford(CreationCost.WindMill))
        {
            BuildFactory.CreateWindMill();
            inventory.Spend(CreationCost.WindMill);
        }
    }
}