using System;
using DepositBuilding;

namespace WoodDepositBuilding
{
    public class WoodDeposit : Deposit
    {
        public WoodDeposit(int endurence, int constructionspeed, int capacity)
            : base(endurence, constructionspeed, capacity)
        {
        }
        public override void Build(int resourceValue)
        {
            Console.WriteLine($"Creando el deposito de madera fue creado con {resourceValue} recursos");
        }
        public void SaveRecourses(int wood) // pasar por parametro wood (arreglar)
        {
            Console.WriteLine("El wood fue guardado en el deposito");
        }
    }      
    
}