using System;
using DepositBuilding;

namespace WindMillDepositBuild
{
    public class WindMill : Deposit
    {
        public int CurrentFood { get; private set; }
        public WindMill(int endurence, int constructionspeed,string name, int resourcevalue,int capacity)
            : base(endurence,constructionspeed, name, resourcevalue, capacity)
        {
            CurrentFood = 0;
        }
        public void StoreFood(int amount)
        {
            if (CurrentFood > MaxCapacity)
            {
                Console.WriteLine("El molino está lleno");
                return;
            }
            CurrentFood += amount;
            Console.WriteLine($"{amount} se almacenó correctamente en el molino. El estado del molino es: {CurrentFood}");
        }
    }      
}