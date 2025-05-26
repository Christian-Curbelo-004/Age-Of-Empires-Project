using CreateBuildings;
using System;

namespace HomeBuilding
{
    public class HomeBuilding : Buildings
    {
        public HomeBuilding(int endurence, int constructionspeed)
            : base(endurence, constructionspeed)
        {
        }
        public override void Build(int resourceValue)
        {
            Console.WriteLine($"Creando Chivarly Center con {resourceValue} recursos"); // que retorne un str
        }
        public void AddCapacity()
        {
            Console.WriteLine("La casa fue creada"); // que retorne un str
        }
    }
}