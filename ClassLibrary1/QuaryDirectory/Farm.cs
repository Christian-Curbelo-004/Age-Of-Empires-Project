using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.QuaryDirectory
{
    public class Farm : IResourceDeposit, IMapEntity
    {
        public int OwnerId { get; set; }
        public (int X, int Y) Position { get; set; }
        public int Speed { get; set; } = 0;
        public int CurrentAmount => Food;
        public int Food { get; private set; }
        public string ResourceType => "Food";

        private int _extractionRate;
        private int _collectionValue;

        public Farm(int ownerId, int initialFood, int extractionRate, int collectionValue)
        {
            OwnerId = ownerId;
            Food = initialFood;
            _extractionRate = extractionRate;
            _collectionValue = collectionValue;
        }

        public int GetResources(int collectors = 1)
        {
            if (Food <= 0) return 0;
            int amount = _extractionRate * collectors;
            int collected = Math.Min(Food, amount);
            Food -= collected;
            return collected;
        }
    }
}