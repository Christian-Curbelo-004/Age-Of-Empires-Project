using System;
using System.Collections.Generic;
using DepositBuilding;

namespace WindMillDepositBuild
{
    public class WindMill : Deposit
    {
        public int CurrentFood { get; private set; }
        public WindMill(int endurence, int constructiontimeleft,string name, int resourcevalue)
            : base(endurence,constructiontimeleft, name, resourcevalue)
        {
            CurrentFood = 0;
        }
        public void StoreFood(int amount)
        {
            int stored = StoreResource(amount);
            CurrentFood += stored;
        }
        public void GetconstructionCost(Dictionary<string,int>ConstruccionCost)
        {
            ConstruccionCost["Piedra"] = 170;
            ConstruccionCost["Madera"] = 100;
        }
    }      
}