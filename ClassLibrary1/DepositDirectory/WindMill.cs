using ClassLibrary1.LogicDirectory;
namespace  ClassLibrary1.DepositDirectory
{
    public class WindMill : Deposit
    {
        public int OwnerId { get; set; }
        public int CurrentFood { get; private set; }
        public WindMill(int endurence, int constructiontimeleft,string name, int maxCapacity, int ownerId)
            : base(endurence,constructiontimeleft, name,  maxCapacity)
        {
            OwnerId = ownerId;
            CurrentFood = 100;
        }
        public void StoreFood(int amount)
        {
            //StoreResource(amount,this.ResourceType);
        }

        public Cost GetCost()
        {
            return new Cost(0, 100, 0, 20);
        }
        public string EntityType => "WindMill";

    }      
}