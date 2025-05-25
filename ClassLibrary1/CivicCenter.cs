using System;
using CreateBuildings;

namespace CivicCenter
{
    public class CivicCenter : Buildings // hereda de buildings los atributos
    {
        public CivicCenter(int endurence, int constructionspeed)
            : base(endurence, constructionspeed)
        {
        }
        public override void Build(int resourceValue)// reescribimos la clase abstracta
        {
            Console.WriteLine($"Creando CivicCenter con {resourceValue} recursos");
        }
        public void CreateVillagers() // metodo
        {
            Console.WriteLine("Aldeanos creados!");
        }
    }
}