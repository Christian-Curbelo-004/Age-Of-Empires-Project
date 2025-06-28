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
            CurrentStone = Math.Min(CurrentStone + amount, MaxCapacity);
        }
        
        public string EntityType => "StoneDeposit";

        public override int ActualResources()
        {
            return CurrentStone;
        }
    }     
}