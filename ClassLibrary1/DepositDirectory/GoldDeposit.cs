using System;
using System.Security.Cryptography.X509Certificates;
using DepositBuilding;

namespace GoldDepositBuild
{
    public class GoldDeposit : Deposit
    {
        public GoldDeposit(int endurence, int constructionspeed, int capacity, string name, int resourcevalue)
            : base(endurence, constructionspeed, capacity, name, resourcevalue)
        {
        }
        public int resourceBuildGD(int resourceValue)
        {
            return resourceValue;
        }
    }      
}
