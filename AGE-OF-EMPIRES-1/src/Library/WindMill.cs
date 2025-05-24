using System;
using DepositBuilding;

namespace WindMillDepositBuild
{
    public class WindMill : Deposit
    {
        public WindMill(int endurence, int constructionspeed, int capacity)
            : base(endurence, constructionspeed, capacity)
        {
        }
        public override void Build(int resourceValue)
        {
            Console.WriteLine($"Creando el deposito de comida fue creado con {resourceValue} recursos");
        }
        public void SaveRecourses(int food) // pasar por parametro food (arreglar)
        {
            Console.WriteLine("El food fue guardado en el deposito");
        }
    }      
    
}