using ClassLibrary1.BuildingsDirectory;

namespace ClassLibrary1.DepositDirectory
{
    public abstract class Deposit : Buildings
    {
        public int MaxCapacity { get; set; } // Capacidad Máxima
        public int CurrentStorage { get; set; } // Capacidad Actual

        public Deposit(int endurence, int constructiontimeleft, string name, int maxCapacity)
            : base(endurence, name)
        {

            MaxCapacity = maxCapacity;
            CurrentStorage = 0;
            ConstructionTime = constructiontimeleft;
        }
    }
}
