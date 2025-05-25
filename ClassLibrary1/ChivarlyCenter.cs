using CreateBuildings;
using System;

namespace ChivarlyCenter
{
    public class ChivarlyCenter : Buildings
    {
        public ChivarlyCenter(int endurence, int constructionspeed)
            : base(endurence, constructionspeed)
        {
        }
        public override void Build(int resourceValue)
        {
            Console.WriteLine($"Creando Chivarly Center con {resourceValue} recursos");
        }
        public void CreateChivarlyCenter()
        {
            Console.WriteLine("Chivarly Center creado!");
        }
    }
}