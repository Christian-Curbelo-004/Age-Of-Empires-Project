using ClassLibrary1.LogicDirectory;

namespace ClassLibrary1.DepositDirectory
{
    public class StoneDeposit : Deposit
    {
        public int OwnerId { get; set; }
        public int CurrentStone { get; private set; }
        public StoneDeposit(int endurence, int constructiontimeleft,string name, int maxCapacity, int ownerId)
            : base(endurence,constructiontimeleft, name,  maxCapacity)
        {
            OwnerId = ownerId;
            
        }
        public void StoreStone(int amount)
        {
            //StoreResource(amount,this.ResourceType);
        }
        public Cost GetCost()
        {
            return new Cost(20, 100, 0, 0);
        }
        public string EntityType => "StoneDeposit";
    }     
}