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

        public override int GetResources(int collectors = 1)
        {
            int amount = base.GetResources(collectors);
            Console.WriteLine($"Se recolectaron {amount} unidades");
            return amount;
        }
    }
}
