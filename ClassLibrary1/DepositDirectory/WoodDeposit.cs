using System;
using DepositBuilding;

namespace WoodDepositBuilding
{
    public class WoodDeposit : Deposit
    {
        public WoodDeposit(int endurence, int constructionspeed,string name, int resourcevalue,int capacity)
            : base(endurence,constructionspeed, name, resourcevalue, capacity)
        {
        }
        public int resourceBuildWD(int resourceValue)
        {
            return resourceValue;
        }
    }      
    
}