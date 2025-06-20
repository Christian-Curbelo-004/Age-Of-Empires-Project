// using System;
// using System.Collections.Generic;
// using DepositBuilding;
// using GameModels;
using GameResourceType = GameModels.GameResourceType;

namespace ClassLibrary1.DepositDirectory
{
    public class WoodDeposit : Deposit
    {
        public int CurrentWood { get; private set; }
        public WoodDeposit(int endurence, int constructiontimeleft,string name,int maxCapacity,GameResourceType resourceType)
            : base(endurence,constructiontimeleft, name, maxCapacity,GameResourceType.Wood)
        {
            CurrentWood = 100;
        }
        public void StoreWood(int amount)
        {
            StoreResource(amount, this.ResourceType);
        }

        public override void SetConstructionCost()
        {
            ConstructionCost[GameResourceType.Stone] = 30;
            ConstructionCost[GameResourceType.Gold] = 10;
        }
    }      
}