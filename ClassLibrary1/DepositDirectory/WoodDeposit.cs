using System;
using System.Collections.Generic;
using DepositBuilding;

namespace WoodDepositBuilding
{
    public class WoodDeposit : Deposit
    {
        public int CurrentWood { get; private set; }
        public WoodDeposit(int endurence, int constructiontimeleft,string name, int resourcevalue)
            : base(endurence,constructiontimeleft, name, resourcevalue)
        {
            CurrentWood = 0;
        }
        public void StoreWood(int amount)
        {
            int stored = StoreResource(amount);
            CurrentWood += stored;
        }
        public void GetconstructionCost(Dictionary<string,int>ConstruccionCost)
        {
            ConstruccionCost["Piedra"] = 30;
            ConstruccionCost["Oro"] = 10;
        }
    }      
    
}