using ClassLibrary1.LogicDirectory;
using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.DepositDirectory
{
    public class StoneDeposit : Deposit, IMapEntity
    {
        public int OwnerId { get; set; }
        public string Symbol { get; set; } = "Sd";
        public override string ToString()
        {
            return $"{Symbol}{OwnerId}"; 
        }
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