using ClassLibrary1.LogicDirectory;
namespace ClassLibrary1.DepositDirectory
{
    public class GoldDeposit : Deposit
    {
        public int OwnerId { get; set; }
        public int CurrentGold { get; private set; } 
        public GoldDeposit(int endurence, int constructionTimeLeft, string name, int maxCapacity, int ownerId)
            : base(endurence, constructionTimeLeft, name, maxCapacity) // GameResourceType.Gold)
        {
            OwnerId = ownerId;
        }
        public void StoreGold(int amount)
        {
            CurrentGold = Math.Min(CurrentGold + amount, MaxCapacity);
        }

        public Cost GetCost()
        {
            return new Cost(0, 100, 0, 150);
        }
        public string EntityType => "GoldDeposit";

        public override int ActualResources()
        {
            return CurrentStorage;
        }

    }      
}
