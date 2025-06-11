using System;
using System.Security.Cryptography.X509Certificates;
using DepositBuilding;

namespace GoldDepositBuild
{
    public class GoldDeposit : Deposit
    {
        public GoldDeposit(int endurence, int constructionspeed,string name, int resourcevalue,int capacity)
            : base(endurence,constructionspeed, name, resourcevalue, capacity)
        {
        }
        public int resourceBuildGD(int resourceValue)
        {
            return resourceValue;
        }
    }      
}
