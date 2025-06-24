using CreateBuildings;
namespace ClassLibrary1.DepositDirectory
{
    public abstract class Deposit : Buildings
    {
        public int MaxCapacity { get; set; }
        public int CurrentStorage { get; set; }

        public Deposit(int endurence, int constructiontimeleft, string name, int maxCapacity)
            : base(endurence, name)
        {

            MaxCapacity = maxCapacity;
            CurrentStorage = 0;
        }
    }
}


//public int StoreResource(int amount, GameResourceType type)
        //{
            //if (type == ResourceType)
            //{
                //int availablespace = MaxCapacity - CurrentStorage;
                //if (availablespace <= 0)
                //{
                    //return 0;
                //}
                //int stored = Math.Min(amount, availablespace);
                //CurrentStorage += stored;
                //return stored;
            //}
            //return 0;
        //}
    //}
//}
