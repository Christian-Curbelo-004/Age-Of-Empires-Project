using System;
using DepositBuilding;

namespace StoneDepositBuild
{
    public class StoneDeposit : Deposit
    {
        public int CurrentStone { get; private set; }
        public StoneDeposit(int endurence, int constructionspeed,string name, int resourcevalue,int capacity)
            : base(endurence,constructionspeed, name, resourcevalue, capacity)
        {
            CurrentStone = 0;
        }
        public void StoreStone(int amount)
        {
            int stored = StoreResource(amount);
            CurrentStone += stored;
        }
        public void GetconstructionCost(Dictionary<string,int>ConstruccionCost)
        {
            ConstruccionCost["Piedra"] = 80;
            ConstruccionCost["Oro"] = 10;
        }
    }      
}