using GameResourceType = GameModels.GameResourceType;

namespace ClassLibrary1.DepositDirectory
{
    public class GoldDeposit : Deposit,  IMapEntidad
    {
        public int CurrentGold { get; private set; } 
        public GoldDeposit(int endurence, int constructionTimeLeft, string name, int maxCapacity)
            : base(endurence, constructionTimeLeft, name,  maxCapacity) // GameResourceType.Gold)
        {
        }
        public void StoreGold(int amount)
        {
            StoreResource(amount, this.ResourceType);
        }
        public override void GetConstructionCost()
        {
            ConstructionCost[GameResourceType.Wood] = 120;
            ConstructionCost[GameResourceType.Stone] = 80;
        }
        public string EntityType => "GoldDeposit";

    }      
}
