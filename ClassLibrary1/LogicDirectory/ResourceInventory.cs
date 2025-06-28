namespace ClassLibrary1.LogicDirectory;

public class ResourceInventory
{
    public int Food { get; private set; }
    public int Wood { get; private set; }
    public int Stone { get; private set; }
    public int Gold { get; private set; }

    public void AddFood(int amount) => Food += amount;
    public void AddWood(int amount) => Wood += amount;
    public void AddStone(int amount) => Stone += amount;
    public void AddGold(int amount) => Gold += amount;

    public void Spend(Cost cost) // Le resto el costo de Creación de la unidad al Inventario (posible cambio)
    {
        Food -= cost.Food;
        Wood -= cost.Wood;
        Gold -= cost.Gold;
        Stone -= cost.Stone;
    }
}