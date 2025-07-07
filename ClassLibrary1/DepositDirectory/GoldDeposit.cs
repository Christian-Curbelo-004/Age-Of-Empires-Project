using ClassLibrary1.LogicDirectory;
using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.DepositDirectory
{
    public class GoldDeposit : Deposit, IMapEntity
    {
        public int OwnerId { get; set; }
        public string Symbol { get; set; } = "Gd";
        public override string ToString()
        {
            return $"{Symbol}{OwnerId}"; 
        }
        public int CurrentGold { get; private set; }
        private readonly ResourceInventory _inventory;

        public GoldDeposit(int endurance, int constructionTimeLeft, string name, int maxCapacity, int ownerId, ResourceInventory inventory)
            : base(endurance, constructionTimeLeft, name, maxCapacity)
        {
            OwnerId = ownerId;
            CurrentGold = 100;
            _inventory = inventory;
        }

        public void StoreGold(int amount)
        {
            int deposited = Math.Min(amount, MaxCapacity - CurrentGold);
            CurrentGold += deposited;
            _inventory.AddGold(deposited);
        }

        public string EntityType => "GoldDeposit";
    }
}