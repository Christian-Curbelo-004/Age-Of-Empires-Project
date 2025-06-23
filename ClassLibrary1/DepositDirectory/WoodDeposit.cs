using GameResourceType = GameModels.GameResourceType;
namespace ClassLibrary1.DepositDirectory
{
    public class WoodDeposit : Deposit, IMapEntity
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
            StoreResource(amount, this.ResourceType);
        }

        public override void GetConstructionCost()
        {
            ConstructionCost[GameResourceType.Stone] = 30;
            ConstructionCost[GameResourceType.Gold] = 10;
        }
        public string EntityType => "WoodDeposit";

    }      
}