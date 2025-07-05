using ClassLibrary1.LogicDirectory;

namespace ClassLibrary1.DepositDirectory
{
    public class GoldDeposit : Deposit
    {
        public int OwnerId { get; set; }
        public int CurrentGold { get; private set; } // Cantidad actual de Oro
        private readonly ResourceInventory inventory;
        public GoldDeposit(int endurence, int constructionTimeLeft, string name, int maxCapacity, int ownerId, ResourceInventory inventory)
            : base(endurence, constructionTimeLeft, name, maxCapacity) 
        {
            OwnerId = ownerId;
            this.inventory = inventory;
        }
        public void StoreGold(int amount)   // Oro almacenado
        {
            int deposited = Math.Min(amount, MaxCapacity - CurrentGold);
            CurrentGold += deposited;
            inventory.AddGold(deposited);
        }
        public string EntityType => "GoldDeposit";
    }      
}
