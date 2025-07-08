namespace ClassLibrary1.LogicDirectory;

public interface IResourceInventory
{
    public int Food { get; set; }
    public int Wood { get; set; }
    public int Stone { get; set; }
    public int Gold { get; set; }
    public void AddFood(int amount) => Food += amount;
    public void AddWood(int amount) => Wood += amount;
    public void AddStone(int amount) => Stone += amount;
    public void AddGold(int amount) => Gold += amount;
    public void Spend(Cost cost);
}