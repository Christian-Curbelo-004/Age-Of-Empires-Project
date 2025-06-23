using ClassLibrary1;
namespace QuaryBiome
{
    public class Forest : Quary
    {
        public Forest(int ExtractionRate, int collectionvalue, string collectiontype, int wood)
            : base(ExtractionRate, collectionvalue, collectiontype)
        {
            Wood = wood;
        }
        public int Wood { get; set; } 

        public override int GetResources()
        {
            int gather = base.GetResources(); 
            if (Wood >= gather)
            {
                Wood -= gather;
                CollectionValue += gather;
                Console.WriteLine($"Se han recolectado {gather} unidades de madera. Madera restante: {Wood}");
                return gather;
            }
            {
                return 0;
            }
        }
    }
}
