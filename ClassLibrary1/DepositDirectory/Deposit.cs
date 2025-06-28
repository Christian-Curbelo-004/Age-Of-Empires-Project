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

        public virtual int ActualResources()
        {
            return 0;
        }
    }
}
