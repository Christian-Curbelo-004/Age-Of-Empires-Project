using ClassLibrary1.LogicDirectory;

namespace ClassLibrary1.DepositDirectory
{
    public class WindMill : Deposit
    {
        public int OwnerId { get; set; }
        public int CurrentFood { get; private set; }
        private readonly ResourceInventory _inventory;

        public WindMill(int endurance, int constructionTimeLeft, string name, int maxCapacity, int ownerId, ResourceInventory inventory)
            : base(endurance, constructionTimeLeft, name, maxCapacity)
        {
            OwnerId = ownerId;
            CurrentFood = 100;
            _inventory = inventory;
        }

        public void StoreFood(int amount)
        {
            int deposited = Math.Min(amount, MaxCapacity - CurrentFood);
            CurrentFood += deposited;
            _inventory.AddFood(deposited);
        }

        public string EntityType => "WindMill";
    }
}