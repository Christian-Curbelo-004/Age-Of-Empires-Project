
namespace ClassLibrary1.DepositDirectory
{
    public class WoodDeposit : Deposit
    {
        public int OwnerId { get; set; }
        public int CurrentWood { get; private set; }
        public WoodDeposit(int endurence, int constructiontimeleft,string name,  int maxCapacity, int ownerId)
            : base(endurence,constructiontimeleft, name, maxCapacity)
        {
            OwnerId = ownerId;
            CurrentWood = 100;
        }
        public void StoreWood(int amount)
        {
           // StoreResource(amount, this.ResourceType);
        }

        public string EntityType => "WoodDeposit";

    }      
}