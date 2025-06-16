using System;
using System.Security.Cryptography.X509Certificates;
using DepositBuilding;

namespace GoldDepositBuild
{
    public class GoldDeposit : Deposit
    {
        public int CurrentGold { get; private set; } 
        public GoldDeposit(int endurence, int constructionspeed,string name, int resourcevalue,int capacity)
            : base(endurence,constructionspeed, name, resourcevalue, capacity)
        {
            CurrentGold = 0;
        }
        public void StoreGold(int amount)
        {
            int stored = StoreResource(amount);
            CurrentGold += stored;
        }
    }      
}
