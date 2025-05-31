using System;
using DepositBuilding;

namespace WoodDepositBuilding
{
    public class WoodDeposit : Deposit
    {
        public WoodDeposit(int endurence, int constructionspeed, int capacity, string name, int resourcevalue)
            : base(endurence, constructionspeed, capacity, name, resourcevalue)
        {
        }
        public int resourceBuildWD(int resourceValue)
        {
            return resourceValue;
        }
    }      
    
}