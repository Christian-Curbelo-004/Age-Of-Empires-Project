using System;
using DepositBuilding;

namespace WindMillDepositBuild
{
    public class WindMill : Deposit
    {
        public WindMill(int endurence, int constructionspeed, int capacity, string name, int resourcevalue)
            : base(endurence, constructionspeed, capacity, name, resourcevalue)
        {
        }
        public int ResourceBuildWM(int resourceValue)
        {
            return resourceValue;
        }
       
    }      
    
}