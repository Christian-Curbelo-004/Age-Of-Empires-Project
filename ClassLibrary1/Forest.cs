using System;
using ClassLibrary1;

namespace QuaryBiome
{
    public class Forest : Quary
    {
        public Forest(int speedfarm, int valueFarm)
            : base(speedfarm, valueFarm)
        {
        }

        public int Wood { get; set; }

        public void GetResources(int amount)
        {
            Wood = amount; // Asignar el valor recibido
            Console.WriteLine(SpeedFarm);
            Console.WriteLine(ValueFarm);
            Console.WriteLine($"Se recolectó {Wood} de madera");
        }
    }

    public class GoldMine : Quary
    {
        public GoldMine(int speedfarm, int valueFarm)
            : base(speedfarm, valueFarm)
        {
        }

        public int Gold { get; set; }

        public void GetResources(int amount)
        {
            Gold = amount; // Asignar el valor recibido
            Console.WriteLine(SpeedFarm);
            Console.WriteLine(ValueFarm);
            Console.WriteLine($"Se recolectó {Gold} de oro");
        }
    }

    public class StoneMine : Quary
    {
        public StoneMine(int speedfarm, int valueFarm)
            : base(speedfarm, valueFarm)
        {
        }
        public int Stone { get; set; }

        public void GetResources(int amount)
        {
            Stone = amount;
            Console.WriteLine(SpeedFarm);
            Console.WriteLine(ValueFarm);
            Console.WriteLine($"Se recolecto {Stone} de oro");
        }
    }
}