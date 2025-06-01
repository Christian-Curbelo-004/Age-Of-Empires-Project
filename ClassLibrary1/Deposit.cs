using CreateBuildings;
using System.IO;



namespace DepositBuilding
{
    public class Deposit : Buildings
    {
        public string Name { get; set; }
        public int Endurence { get; set; }
        public int ConstructionSpeed { get; set; }
        public int ResourceValue { get; set; }
        public int Capacity { get;  set; }
        public int MaxCapacity { get; set; }

        public Deposit(int endurence, int constructionspeed, int capacity, string name, int resourcevalue)
            : base(endurence, constructionspeed, name, capacity, resourcevalue)
        {
            this.Endurence = endurence;
            this.ConstructionSpeed = constructionspeed;
            this.Capacity = capacity;
            this.Name = name;
            this.ResourceValue = resourcevalue;
            this.MaxCapacity = MaxCapacity;
        }

    }
}
