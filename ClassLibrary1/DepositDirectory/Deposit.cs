using System;
using CreateBuildings;
using System.IO;
namespace DepositBuilding
{
    public class Deposit : Buildings
    {
        public int MaxCapacity { get; set; }
        public int CurrentStorage { get; set; }

        public Deposit(int endurence, int constructionspeed, string name,int resourcevalue, int capacity)
            : base(endurence, constructionspeed, name, resourcevalue, capacity)
        {
            this.MaxCapacity = capacity;
        }

        public int StoreResource(int amount)
        {
            int availablespace = MaxCapacity - CurrentStorage;

            if (availablespace <= 0)
            {
                Console.WriteLine("El deposito está lleno");
                return 0;
            }

            int stored = Math.Min(amount, availablespace);
            CurrentStorage += stored;
            
            
            Console.WriteLine($"{stored} unidades almacenadas en {Name}. Total actual: {CurrentStorage}/{MaxCapacity}");
            return stored;
        }
    }
}
