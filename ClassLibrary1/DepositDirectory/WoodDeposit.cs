using ClassLibrary1.DepositDirectory;
using ClassLibrary1.LogicDirectory;

public class WoodDeposit : Deposit
{
    public int OwnerId { get; set; }
    public int CurrentWood { get; private set; } 
    private readonly ResourceInventory inventory;

    public WoodDeposit(int endurence, int constructiontimeleft, string name, int maxCapacity, int ownerId, ResourceInventory inventory)
        : base(endurence, constructiontimeleft, name, maxCapacity)
    {
        OwnerId = ownerId;
        CurrentWood = 100;
        this.inventory = inventory;
    }

    public void StoreWood(int amount) 
    {
        int deposited = Math.Min(amount, MaxCapacity - CurrentWood);
        CurrentWood += deposited;
        inventory.AddWood(deposited); 
    }

    public string EntityType => "WoodDeposit";
}