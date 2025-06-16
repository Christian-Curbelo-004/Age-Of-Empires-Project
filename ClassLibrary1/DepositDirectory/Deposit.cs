using CreateBuildings;
using System.IO;
namespace DepositBuilding
{
    public class Deposit : Buildings
    {
        public int MaxCapacity { get; set; }

        public Deposit(int endurence, int constructionspeed, string name,int resourcevalue, int capacity)
            : base(endurence, constructionspeed, name, capacity, resourcevalue)
        {
            this.MaxCapacity = Capacity;
        }
    }
}
