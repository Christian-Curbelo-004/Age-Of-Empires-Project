namespace ClassLibrary1.QuaryDirectory
{
    public class Forest : Quary
    {
        public int Wood { get; private set; }

        public Forest(int extractionRate, int collectionValue, int initialWood)
            : base(extractionRate, collectionValue, initialWood, "Wood")
        {
            Wood = initialWood;
        }

        public ResourceResult CollectResources(int collectors = 1)
        {
            int amount = base.GetResources(collectors);

            if (Wood <= 0)
            {
                return new ResourceResult(0, "El bosque está vacía.");
            }

            int collected = Math.Min(Wood, amount);
            Wood -= collected;

            string message = $"Se recolectaron {collected} unidades de madera.";
            return new ResourceResult(collected, message);
        }
    }
}