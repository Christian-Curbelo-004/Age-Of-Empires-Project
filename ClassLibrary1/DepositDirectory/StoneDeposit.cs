using ClassLibrary1.LogicDirectory;

namespace ClassLibrary1.DepositDirectory
{
    public class StoneDeposit : Deposit
    {
        public int OwnerId { get; set; }
        public int CurrentStone { get; private set; }
        private readonly ResourceInventory _inventory;

        public StoneDeposit(int endurance, int constructionTimeLeft, string name, int maxCapacity, int ownerId, ResourceInventory inventory)
            : base(endurance, constructionTimeLeft, name, maxCapacity)
        {
            OwnerId = ownerId;
            CurrentStone = 100;
            _inventory = inventory;
        }

        public void StoreStone(int amount)
        {
            int deposited = Math.Min(amount, MaxCapacity - CurrentStone);
            CurrentStone += deposited;
            _inventory.AddStone(deposited);
        }

        public string EntityType => "StoneDeposit";
    }
}