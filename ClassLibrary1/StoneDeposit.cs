using System;
using DepositBuilding;

namespace StoneDepositBuild
{
    public class StoneDeposit : Deposit
    {
        public StoneDeposit(int endurence, int constructionspeed,string name, int resourcevalue, int capacity)
            : base(endurence, constructionspeed, capacity, name, resourcevalue)
        {
        }
        public int resourceBuildSD(int resourceValue)
        {
            return resourceValue;
        }
        
    }      
}