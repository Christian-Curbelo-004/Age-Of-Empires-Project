namespace ClassLibrary1.LogicDirectory;

public class ResourceInventory : IResourceInventory
{
    public int Food { get; set; }
    public int Wood { get; set; }
    public int Stone { get; set; }
    public int Gold { get; set; }

    public void AddFood(int amount) => Food += amount;
    public void AddWood(int amount) => Wood += amount;
    public void AddStone(int amount) => Stone += amount;
    public void AddGold(int amount) => Gold += amount;

    public void Spend(Cost cost) // Le resto el costo de Creación de la unidad al Inventario 
    {
        Food -= cost.Food;
        Wood -= cost.Wood;
        Gold -= cost.Gold;
        Stone -= cost.Stone;
    }
    // Creo que no se usa
    public Dictionary<string, int> ResourceCollectionCup()
    {
        return new Dictionary<string, int>()
        {
            { "gold", 4 }, { "stone", 5 }, { "wood", 6 }, { "food", 5 }
        };
    }
}