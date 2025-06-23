namespace ClassLibrary1.QuaryDirectory
{
    public class Farm : Quary
    {
        public int Food { get; private set; }

        public Farm(int extractionRate, int collectionValue, int initialFood)
            : base(extractionRate, collectionValue, initialFood, 300,"Food")
        {
            Food = initialFood;
        }

        public ResourceResult CollectResources(int collectors = 1)
        {
            int amount = base.GetResources(collectors);

            if (Food <= 0)
            {
                return new ResourceResult(0, "La granja está vacía.");
            }

            int collected = Math.Min(Food, amount);
            Food -= collected;

            string message = $"Se recolectaron {collected} unidades de comida.";
            return new ResourceResult(collected, message);
        }
    }
}