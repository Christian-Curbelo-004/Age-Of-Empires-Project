using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.MapDirectory;
namespace ClassLibrary1.LogicDirectory;

public class UnitCreateCore
{
    private readonly IResourceInventory inventory;
    private readonly UnitAffordable unitAffordable;
    private readonly Map map;
    private readonly KnowingCell knowingCell;
    private readonly Player player;

    public UnitCreateCore(IResourceInventory resourceInventory, Map map, Player player, KnowingCell knowingCell,
        UnitAffordable unitAffordable)
    {
        this.inventory = resourceInventory;
        this.unitAffordable = unitAffordable;
        this.map = map;
        this.knowingCell = knowingCell;
        this.player = player;
    }

    private bool CanCreateUnit(Buildings building, Cost cost)
    {
        return building.IsConstructed && knowingCell.CheckPopulation(player.Id) >= 1 && unitAffordable.CanAfford(cost);
    }

    public void ReturnArcher(ArcherCenter archerCenter)
    {
        if (CanCreateUnit(archerCenter, CreationCost.Archer))
        {
            UnitFactory.CreateArcher();
            inventory.Spend(CreationCost.Archer);
        }
    }

    public void ReturnCenturies(CenturiesCenter centuriesCenter, Civilization civilization, Roman roman)
    {
        if (civilization == roman)
        {
            if (CanCreateUnit(centuriesCenter, CreationCost.Centuries))
            {
                UnitFactory.CreateCenturies();
                inventory.Spend(CreationCost.Centuries);
            }
        }

    }

    public void ReturnPaladin(PaladinCenter paladinCenter, Civilization civilization, Templaries templaries)
    {
        if (civilization == templaries)
        {
            if (CanCreateUnit(paladinCenter, CreationCost.Paladin))
            {
                UnitFactory.CreatePaladin();
                inventory.Spend(CreationCost.Paladin);
            }
        }
    }

    public void ReturnInfantery(InfanteryCenter infanteryCenter)
    {
        if (CanCreateUnit(infanteryCenter, CreationCost.Infantery))
        {
            UnitFactory.CreateInfantery();
            inventory.Spend(CreationCost.Infantery);
        }
    }

    public void ReturnChivarly(ChivarlyCenter chivarlyCenter)
    {
        if (CanCreateUnit(chivarlyCenter, CreationCost.Chivarly))
        {
            UnitFactory.CreateChivarly();
            inventory.Spend(CreationCost.Chivarly);
        }
    }

    public void ReturnRaider(RaiderCenter raiderCenter, Civilization civilization, Viking viking)
    {
        if (civilization == viking)
        {
            if (CanCreateUnit(raiderCenter, CreationCost.Raider))
            {
                UnitFactory.CreateRaider();
                inventory.Spend(CreationCost.Raider);
            }
        }
    }

    public void ReturnVillager(CivicCenter civicCenter)
    {
        if (CanCreateUnit(civicCenter, CreationCost.Villagers))
        {
            UnitFactory.CreateVillagers();
            inventory.Spend(CreationCost.Villagers);
        }
    }
}