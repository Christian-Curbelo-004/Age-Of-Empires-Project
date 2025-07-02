using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.MapDirectory;
using ClassLibrary1.FacadeDirectory;
namespace ClassLibrary1.LogicDirectory;

public class UnitCreateCore
{
    private readonly IResourceInventory inventory;
    private readonly UnitAffordable unitAffordable;
    private readonly Map map;
    private readonly KnowingCell knowingCell;
    private readonly Player player;
    public UnitCreateCore(IResourceInventory resourceInventory, Map map, Player player)
    {
        this.inventory = resourceInventory;
        this.unitAffordable = new UnitAffordable(resourceInventory);
        this.map = map;
        this.knowingCell = new KnowingCell(map);
        this.player = player;
    }
    public void ReturnArcher(ArcherCenter archerCenter)
    {
        if (archerCenter.IsConstructed)
        {
            if (knowingCell.CheckPopulation(player.Id) >= 1)
            {
                if (unitAffordable.CanAfford(CreationCost.Archer))
                {
                    UnitFactory.CreateArcher();
                    inventory.Spend(CreationCost.Archer);
                }
            }
        }
    }
    public void ReturnCenturies(CenturiesCenter centuriesCenter)
    {
        if (centuriesCenter.IsConstructed)
        {
            if (knowingCell.CheckPopulation(player.Id) >= 1)
            {
                if (unitAffordable.CanAfford(CreationCost.Centuries))
                {
                    UnitFactory.CreateCenturies();
                    inventory.Spend(CreationCost.Centuries);
                }
            }
        }
    }
    public void ReturnPaladin(PaladinCenter paladinCenter)
    {
        if (paladinCenter.IsConstructed)
        {
            if (knowingCell.CheckPopulation(player.Id) >= 1)
            {
                if (unitAffordable.CanAfford(CreationCost.Paladin))
                {
                    UnitFactory.CreatePaladin();
                    inventory.Spend(CreationCost.Paladin);
                }
            }
        }
    }
    public void ReturnInfantery(InfanteryCenter infanteryCenter)
    {
        if (infanteryCenter.IsConstructed)
        {
            if (knowingCell.CheckPopulation(player.Id) >= 1)
            {
                if (unitAffordable.CanAfford(CreationCost.Infantery))
                {
                    UnitFactory.CreateInfantery();
                    inventory.Spend(CreationCost.Infantery);
                }
            }
        }
    }
    public void ReturnChivarly(ChivarlyCenter chivarlyCenter)
    {
        if (chivarlyCenter.IsConstructed)
        {
            if (knowingCell.CheckPopulation(player.Id) >= 1)
            {
                if (unitAffordable.CanAfford(CreationCost.Chivarly))
                {
                    UnitFactory.CreateChivarly();
                    inventory.Spend(CreationCost.Chivarly);
                }
            }
        }
    }
    public void ReturnRaider(RaiderCenter raiderCenter)
    {
        if (raiderCenter.IsConstructed)
        {
            if (knowingCell.CheckPopulation(player.Id) >= 1)
            {
                if (unitAffordable.CanAfford(CreationCost.Raider))
                {
                    UnitFactory.CreateRaider();
                    inventory.Spend(CreationCost.Raider);
                }
            }
        }
    }
    public void ReturnVillager(CivicCenter civicCenter)
    { 
        if (civicCenter.IsConstructed)
        {
            if (knowingCell.CheckPopulation(player.Id) >= 1)
            {
                if (unitAffordable.CanAfford(CreationCost.Villagers))
                {
                    UnitFactory.CreateVillagers();
                    inventory.Spend(CreationCost.Villagers);
                }
            }
        }
    }
    
}