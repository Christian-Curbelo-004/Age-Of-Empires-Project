using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DepositBuilding;

namespace GoldDepositBuild
{
    public class GoldDeposit : Deposit
    {
        public int CurrentGold { get; private set; } 
        public GoldDeposit(int endurence, int constructiontimeleft,string name, int resourcevalue)
            : base(endurence,constructiontimeleft, name, resourcevalue)
        {
            CurrentGold = 0;
        }
        public void StoreGold(int amount)
        {
            int stored = StoreResource(amount);
            CurrentGold += stored;
        }
        public void GetconstructionCost(Dictionary<string,int>ConstruccionCost)
        {
            ConstruccionCost["Madera"] = 110;
            ConstruccionCost["Piedra"] = 35;
        }
    }      
}
