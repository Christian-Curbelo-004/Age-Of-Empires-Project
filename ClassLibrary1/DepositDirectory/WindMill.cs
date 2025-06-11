using System;
using DepositBuilding;

namespace WindMillDepositBuild
{
    public class WindMill : Deposit
    {
        public WindMill(int endurence, int constructionspeed,string name, int resourcevalue,int capacity)
            : base(endurence,constructionspeed, name, resourcevalue, capacity)
        {
        }
        public int ResourceBuildWM(int resourceValue)
        {
            return resourceValue;
        }
       
    }      
    
}