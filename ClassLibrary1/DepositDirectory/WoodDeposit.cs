using ClassLibrary1.LogicDirectory;
namespace ClassLibrary1.DepositDirectory
{
    public class WoodDeposit : Deposit
    {
        public int OwnerId { get; set; }
        public int CurrentWood { get; private set; } // Actual de Madera 
        private readonly ResourceInventory inventory;
        public WoodDeposit(int endurence, int constructiontimeleft,string name,  int maxCapacity, int ownerId, ResourceInventory inventory)
            : base(endurence,constructiontimeleft, name, maxCapacity)
        {
            OwnerId = ownerId;
            CurrentWood = 100;
        }
        public void StoreWood(int amount) // Madera Almacenada
        {
            int deposited = Math.Min(amount, MaxCapacity - CurrentWood);
            CurrentWood += deposited;
            inventory.AddGold(deposited);
        }
        public string EntityType => "WoodDeposit";
    }      
}