using GameModels;

namespace ClassLibrary1.DepositDirectory
{
    public class StoneDeposit : Deposit, IMapEntidad
    {
        public int CurrentStone { get; private set; }
        public StoneDeposit(int endurence, int constructiontimeleft,string name, int maxCapacity)
            : base(endurence,constructiontimeleft, name,  maxCapacity)
        {
        }
        public void StoreStone(int amount)
        {
            StoreResource(amount,this.ResourceType);
         
        }

        public override void GetConstructionCost()
        {
            ConstructionCost[GameResourceType.Stone] = 80;
            ConstructionCost[GameResourceType.Gold] = 10;
        }
        public string EntityType => "StoneDeposit";

    }      
}