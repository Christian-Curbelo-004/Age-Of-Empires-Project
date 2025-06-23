namespace ClassLibrary1.QuaryDirectory
{
    public class StoneMine : Quary
    {
        public int Stone { get; private set; }

        public StoneMine(int extractionRate, int collectionValue, int initialStone)
            : base(extractionRate, collectionValue, initialStone, 300, "Stone")
        {
            Stone = initialStone;
        }

        public ResourceResult CollectResources(int collectors = 1)
        {
            int amount = base.GetResources(collectors);

            if (Stone <= 0)
            {
                return new ResourceResult(0, "La mina de piedra está vacía.");
            }

            int collected = System.Math.Min(Stone, amount);
            Stone -= collected;

            string message = $"Se recolectaron {collected} unidades de piedra.";
            return new ResourceResult(collected, message);
        }
    }
}