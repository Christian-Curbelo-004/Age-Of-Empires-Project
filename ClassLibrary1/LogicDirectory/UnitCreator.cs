namespace ClassLibrary1.LogicDirectory;

public class UnitCreator
{
    private readonly ResourceInventory inventory; //Uso el inventario global del jugador
    public UnitCreator(ResourceInventory resourceInventory)
    {
        this.inventory = resourceInventory;
    }
    public bool CanAfford( Cost cost) // Evaluo si tengo los recursos necesarios 
    {

        return inventory.Food >= cost.Food && inventory.Wood >= cost.Wood && inventory.Stone >= cost.Stone &&
               inventory.Gold >= cost.Gold;
    }

    public bool CreateUnit(Cost cost) // Devuelvo si se puede crear la unidad
    {
        if (CanAfford(cost))
        {
            inventory.Spend(cost);
            return true;
        }
        return false;
    }
}