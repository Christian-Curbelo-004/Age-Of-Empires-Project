using System;
using System.Collections.Generic;
using DepositBuilding;

namespace StoneDepositBuild
{
    public class StoneDeposit : Deposit
    {
        public int CurrentStone { get; private set; }
        public StoneDeposit(int endurence, int constructiontimeleft,string name, int resourcevalue)
            : base(endurence,constructiontimeleft, name, resourcevalue)
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