using ClassLibrary1.UnitsDirectory;
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
    public Soldier? TryCreateUnit<T>(Buildings building, Cost cost, Civilization civilization, Func<Civilization, bool> civCondition, Func<Soldier> createUnit)
        where T : Buildings
    {
        if (!civCondition(civilization))
            return null;

        if (!CanCreateUnit(building, cost))
            return null;

        inventory.Spend(cost);
        return createUnit();
    }
    public GameUnit? TryCreateVillager<T>(
        Buildings building,
        Cost cost,
        Func<GameUnit> createVillager
    )
        where T : Buildings
    {
        if (!CanCreateUnit(building, cost))
            return null;

        inventory.Spend(cost);
        return createVillager();
    }
    private bool CanCreateUnit(Buildings building, Cost cost)
    {
        return building.IsConstructed && knowingCell.CheckPopulation(player.Id) >= 1 && unitAffordable.CanAfford(cost);
    }

}