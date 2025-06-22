// using System;
// using System.Collections.Generic;
// using DepositBuilding;
using GameModels;

namespace  ClassLibrary1.DepositDirectory
{
    public class WindMill : Deposit, IMapEntidad
    {
        public int CurrentFood { get; private set; }
        public WindMill(int endurence, int constructiontimeleft,string name,int maxCapacity)
            : base(endurence,constructiontimeleft, name, maxCapacity)
        {
            CurrentFood = 100;
        }
        public void StoreFood(int amount)
        {
            StoreResource(amount,this.ResourceType);
        }
        public override void GetConstructionCost()
        {
            ConstructionCost[GameResourceType.Stone] = 170;
            ConstructionCost[GameResourceType.Wood] = 100;
        }
        public string EntityType => "WindMill";

    }      
}