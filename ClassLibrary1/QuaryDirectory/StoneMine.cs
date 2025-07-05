namespace ClassLibrary1.QuaryDirectory
{
    public class StoneMine : Quary
    {
        public int OwnerId { get; set; }
        public int CurrentAmount
        {
            get => Stone;
            set => Stone = value;
        }

        private readonly IResourceCollector _collector;
        public int Stone { get; private set; }
        public string ResourceType => "Stone";

        public StoneMine(int ownerId, int initialStone, int extractionRate, int collectionValue, IResourceCollector collector)
            : base(ownerId, extractionRate, collectionValue,initialStone )
        {
            OwnerId = ownerId;
            _collector = collector;
            CurrentAmount = initialStone;
        }

        public int GetResources(int collectors)
        {
            int collected = _collector.CalculateCollected(Stone, ExtractionRate, collectors);
            Stone -= collected;
            return collected;
        }
    }
}