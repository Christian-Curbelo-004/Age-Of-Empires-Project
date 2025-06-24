
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
 
            //ResourceType = GameResourceType.Gold;
        }
        public void StoreGold(int amount)
        {
            //StoreResource(amount, this.ResourceType);
        }
        
        public string EntityType => "GoldDeposit";

    }      
}
