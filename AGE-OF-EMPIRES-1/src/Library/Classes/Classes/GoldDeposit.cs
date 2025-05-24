using System;
using System.Security.Cryptography.X509Certificates;
using DepositBuilding;

namespace GoldDepositBuild
{
    public class GoldDeposit : Deposit
    {
        public GoldDeposit(int endurence, int constructionspeed, int capacity)
            : base(endurence, constructionspeed, capacity)
        {
        }
        public override void Build(int resourceValue)
        {
            Console.WriteLine($"Creando el deposito de oro fue creado con {resourceValue} recursos");
        }
        public void SaveRecourses(int Gold) // pasar por parametro gold (arreglar)
        {
            Console.WriteLine("El oro fue guardado en el deposito");
        }
    }      
    
}