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

        public int GetResources()
        {
            Console.WriteLine(CollectionSpeed);
            Console.WriteLine(CollectionValue);
            int collected = CollectionSpeed * CollectionValue;
            Console.WriteLine($"Se recolectó {collected} de madera");
            return collected;
        }
    }
}
