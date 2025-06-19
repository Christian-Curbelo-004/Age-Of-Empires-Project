using System;
using System.Collections.Generic;
using DepositBuilding;
using GameModels;

namespace StoneDepositBuild
{
    public class StoneDeposit : Deposit
    {
        public int CurrentStone { get; private set; }
        public StoneDeposit(int endurence, int constructiontimeleft,string name,int maxCapacity, GameResourceType resourceType)
            : base(endurence,constructiontimeleft, name, maxCapacity,GameResourceType.Stone)
        {
        }
        public void StoreStone(int amount)
        {
            StoreResource(amount,this.ResourceType);
         
        }

        public override void SetConstructionCost()
        {
            ConstructionCost[GameResourceType.Stone] = 80;
            ConstructionCost[GameResourceType.Gold] = 10;
        }
    }      
}