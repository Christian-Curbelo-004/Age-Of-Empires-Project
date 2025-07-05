

namespace ClassLibrary1.QuaryDirectory
{
    public class Farm : Quary
    {
        public int OwnerId { get; set; }
        public int CurrentAmount
        {
            get => Food;
            set => Food = value;
        }

        private readonly IResourceCollector _collector;
        public string ResourceType => "Food";
        public int Food { get; private set; }
        
        public Farm(int ownerId, int initialFood, int extractionRate, int collectionValue, IResourceCollector collector)
            : base(ownerId, extractionRate, collectionValue,initialFood )
        {
            OwnerId = ownerId;
            _collector = collector;
            CurrentAmount = initialFood;
        }
        public int GetResources(int collectors)
        {
            int collected = _collector.CalculateCollected(Food, ExtractionRate,collectors);
            Food -= collected;
            return collected;
        }
    }
}