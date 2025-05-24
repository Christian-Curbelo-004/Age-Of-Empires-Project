using System;
using DepositBuilding;

namespace StoneDepositBuild
{
    public class StoneDeposit : Deposit
    {
        public StoneDeposit(int endurence, int constructionspeed, int capacity)
            : base(endurence, constructionspeed, capacity)
        {
        }
        public override void Build(int resourceValue)
        {
            Console.WriteLine($"Creando el deposito de piedra fue creado con {resourceValue} recursos");
        }
        public void SaveRecourses(int stone) // pasar por parametro piedra (arreglar)
        {
            Console.WriteLine("El piedra fue guardado en el deposito");
        }
    }      
    
}