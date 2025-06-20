// using System;
// using System.Collections.Generic;
// using DepositBuilding;
using GameModels;

namespace  ClassLibrary1.DepositDirectory
{
    public class WindMill : Deposit
    {
        public int CurrentFood { get; private set; }
        public WindMill(int endurence, int constructiontimeleft,string name,int maxCapacity,GameResourceType resourceType)
            : base(endurence,constructiontimeleft, name, maxCapacity, GameResourceType.Food)
        {
            CurrentFood = 100;
        }
        public void StoreFood(int amount)
        {
            StoreResource(amount,this.ResourceType);
        }
        public override void SetConstructionCost()
        {
            ConstructionCost[GameResourceType.Stone] = 170;
            ConstructionCost[GameResourceType.Wood] = 100;
        }
    }      
}