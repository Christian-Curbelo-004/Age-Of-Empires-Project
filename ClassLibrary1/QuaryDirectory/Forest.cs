using System;
using ClassLibrary1;

namespace QuaryBiome
{
    public class Forest : Quary
    {
        public Forest(int collectionspeed, int collectionvalue)
            : base(collectionspeed, collectionvalue)
        {
        }

        public int Wood { get; set; }

        public void GetResources(int amount)
        {
            Wood = amount; 
            Console.WriteLine(CollectionSpeed);
            Console.WriteLine(CollectionValue);
            Console.WriteLine($"Se recolectó {Wood} de madera");
        }
    }
}
