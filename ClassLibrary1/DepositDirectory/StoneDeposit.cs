using ClassLibrary1.LogicDirectory;

namespace ClassLibrary1.DepositDirectory
{
    public class StoneDeposit : Deposit
    {
        public int OwnerId { get; set; }
        public int CurrentStone { get; private set; } // Piedra actual
        private readonly ResourceInventory inventory;
        public StoneDeposit(int endurence, int constructiontimeleft,string name, int maxCapacity, int ownerId, ResourceInventory inventory)
            : base(endurence,constructiontimeleft, name,  maxCapacity)
        {
            OwnerId = ownerId;
            this.inventory = inventory;
        }
        public void StoreStone(int amount) // Piedtra Almacenada (Falta implementar en aldeanos o algo de eso)
        {
            int deposited = Math.Min(amount, MaxCapacity - CurrentStone);
            CurrentStone += deposited;
            inventory.AddStone(deposited);
        }
        public string EntityType => "StoneDeposit";
    }     
}