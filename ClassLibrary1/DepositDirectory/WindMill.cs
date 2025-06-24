using GameModels;

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
            StoreResource(amount,this.ResourceType);
        }

        public string EntityType => "WindMill";

    }      
}