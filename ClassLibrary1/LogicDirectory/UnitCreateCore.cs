using ClassLibrary1.MapDirectory;
using ClassLibrary1.FacadeDirectory;
namespace ClassLibrary1.LogicDirectory;

public class UnitCreateCore
{
    private readonly ResourceInventory inventory;
    private readonly UnitAffordable unitAffordable;
    private readonly Map map;
    private readonly KnowingCell knowingCell;
    private readonly Player player;
    
    public UnitCreateCore(ResourceInventory resourceInventory, Map map, Player player)
    {
        this.inventory = resourceInventory;
        this.unitAffordable = new UnitAffordable(resourceInventory);
        this.map = map;
        this.knowingCell = new KnowingCell(map);
        this.player = player;
    }
    public void ReturnArcher()
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
    public void ReturnCenturies()
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
    public void ReturnPaladin()
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
    public void ReturnInfantery()
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
    public void ReturnChivarly()
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
    public void ReturnRaider()
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
    public void ReturnVillager()
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