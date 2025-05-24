using System;
using CreateBuildings;

namespace DepositBuilding
{
    public class Deposit : Buildings
    {
        public int Capacity { get; set; }
        public Deposit(int endurence, int constructionspeed, int capacity)
            : base(endurence, constructionspeed)
        {
            Capacity = capacity;
        }
        public override void Build(int resourceValue)
        {
            Console.WriteLine($"Creando el deposito con {resourceValue} recursos");
        }
        public void SaveRecourses()
        {
            Console.WriteLine("Recursos guardados");
        }

    }
}