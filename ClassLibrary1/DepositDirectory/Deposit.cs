using System;
using CreateBuildings;
using System.IO;
namespace DepositBuilding
{
    public class Deposit : Buildings
    {
        public int MaxCapacity { get; set; }
        public int CurrentStorage { get; set; }
        public Deposit(int endurence, int constructiontimeleft, string name,int resourcevalue)
            : base(endurence, constructiontimeleft, name, resourcevalue)
        {
        }
        
        public int StoreResource(int amount)
        {
            int availablespace = MaxCapacity - CurrentStorage;
            if (availablespace <= 0)
            {
                return 0;
            }
            int stored = Math.Min(amount, availablespace);
            CurrentStorage += stored;
            return stored;
        }
    }
}
