using ClassLibrary1.LogicDirectory;
namespace  ClassLibrary1.DepositDirectory
{
    public class WindMill : Deposit
    {
        public int OwnerId { get; set; }
        public int CurrentFood { get; private set; } // Comida actual
        private readonly ResourceInventory inventory;
        public WindMill(int endurence, int constructiontimeleft,string name, int maxCapacity, int ownerId, ResourceInventory inventory)
            : base(endurence,constructiontimeleft, name,  maxCapacity)
        {
            OwnerId = ownerId;
            CurrentFood = 100;
            this.inventory = inventory;
        }
        public void StoreFood(int amount) // Comida Almacenada
        {
            int deposited = Math.Min(amount, MaxCapacity - CurrentFood);
            CurrentFood += deposited;
            inventory.AddGold(deposited);
        }
        public string EntityType => "WindMill";

        public override int ActualResources()
        {
            return CurrentFood;
        }

    }      
}