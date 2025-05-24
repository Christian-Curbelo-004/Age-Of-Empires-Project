using System;
using CreateBuildings;

namespace InfanteryCenter
{
    public class InfanteryCenter : Buildings
    {
        public InfanteryCenter(int endurence, int constructionspeed)
            : base(endurence, constructionspeed)
        {
        }
        public override void Build(int resourceValue)
        {
            Console.WriteLine($"Creando Infantery center con {resourceValue} recursos");
        }
        public void CreateInfanteryCenter()
        {
            Console.WriteLine("Infantery Center creado!");
        }
    }
}