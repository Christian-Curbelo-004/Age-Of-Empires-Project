using System;
using DepositBuilding;

namespace WoodDepositBuilding
{
    public class WoodDeposit : Deposit
    {
        public int CurrentWood { get; private set; }
        public WoodDeposit(int endurence, int constructionspeed,string name, int resourcevalue,int capacity)
            : base(endurence,constructionspeed, name, resourcevalue, capacity)
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