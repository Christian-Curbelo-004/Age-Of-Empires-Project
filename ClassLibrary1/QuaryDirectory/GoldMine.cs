namespace ClassLibrary1.QuaryDirectory
{
    public class GoldMine : Quary
    {
        public int Gold { get; private set; }

        public GoldMine(int extractionRate, int collectionValue, int initialGold)
            : base(extractionRate, collectionValue, initialGold, 300, "Oro")
        {
            Gold = initialGold;
        }

        public ResourceResult CollectResources(int collectors = 1)
        {
            int amount = base.GetResources(collectors);

            if (Gold <= 0)
            {
                return new ResourceResult(0, "La mina de oro está vacía.");
            }

            int collected = Math.Min(Gold, amount);
            Gold -= collected;

            string message = $"Se recolectaron {collected} unidades de oro.";
            return new ResourceResult(collected, message);
        }
    }
}