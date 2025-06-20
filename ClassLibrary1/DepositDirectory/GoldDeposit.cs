// using System;
// using System.Collections.Generic;
using System.Security.AccessControl;
// using DepositBuilding;
using GameResourceType = GameModels.GameResourceType;

namespace ClassLibrary1.DepositDirectory
{
    public class GoldDeposit : Deposit
    {
        public int CurrentGold { get; private set; } 
        public GoldDeposit(int endurence, int constructionTimeLeft, string name, int maxCapacity, ResourceType resourceType)
            : base(endurence, constructionTimeLeft, name, maxCapacity, GameResourceType.Gold)
        {
        }
        public void StoreGold(int amount)
        {
            StoreResource(amount, this.ResourceType);
        }
        public override void SetConstructionCost()
        {
            ConstructionCost[GameResourceType.Wood] = 120;
            ConstructionCost[GameResourceType.Stone] = 80;
        }
    }      
}
