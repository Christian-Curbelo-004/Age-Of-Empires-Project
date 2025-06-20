using System;
using ClassLibrary1;

namespace QuaryBiome
{
    public class Forest : Quary
    {
        public Forest(int collectiontimeleft, int collectionvalue, string collectiontype, int wood)
            : base(collectiontimeleft, collectionvalue, collectiontype)
        {
            Wood = wood;
        }

        public int Wood { get; set; } 

        public override int GetResources()
        {
            int recolectado = base.GetResources(); 
            if (Wood >= recolectado)
            {
                Wood -= recolectado;
                Console.WriteLine($"Se han recolectado {recolectado} unidades de madera. Madera restante: {Wood}");
                return recolectado;
            }
            else
            {
                Console.WriteLine("No hay suficiente madera para recolectar.");
                return 0;
            }
        }
    }
}
