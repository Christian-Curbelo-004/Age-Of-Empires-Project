using System;
using CreateBuildings;
using System.IO;
using GameModels;

namespace DepositBuilding
{
    public abstract class Deposit : Buildings
    {
        public GameResourceType ResourceType { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentStorage { get; set; }

        public Deposit(int endurence, int constructiontimeleft, string name,int maxCapacity,GameResourceType resourceType)
            : base(endurence, constructiontimeleft, name)
        {
            ResourceType = resourceType;
            MaxCapacity = maxCapacity;
            CurrentStorage = 0;
        }
        public abstract override void SetConstructionCost();
        
        public int StoreResource(int amount, GameResourceType type)
        {
            if (type == ResourceType)
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
            return 0;
        }
    }
}
