namespace ClassLibrary1.LogicDirectory;

public class UnitAffordable
{
    private readonly IResourceInventory inventory; //Uso el inventario global del jugador
    public UnitAffordable(IResourceInventory resourceInventory)
    {
        this.inventory = resourceInventory;
    }
    public bool CanAfford( Cost cost) // Evaluo si tengo los recursos necesarios 
    {

        return inventory.Food >= cost.Food && inventory.Wood >= cost.Wood && inventory.Stone >= cost.Stone &&
               inventory.Gold >= cost.Gold;
    }
}