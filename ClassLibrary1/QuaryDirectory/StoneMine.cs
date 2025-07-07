using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.QuaryDirectory
{
    public class StoneMine : Quary, IMapEntity
    {
        public int OwnerId { get; set; }
        public (int X, int Y) Position { get; set; }
        public string Name { get; set; } = "Stone Mine";

        private readonly IResourceCollector _collector;

        public int CurrentAmount
        {
            get => Stone;
            set => Stone = value;
        }

        public int Stone { get; private set; }
        public string ResourceType => "Stone";

        public StoneMine(int x, int y, int initialStone, int extractionRate, int collectionValue, int ownerId,
            IResourceCollector collector)
            : base(ownerId, extractionRate, collectionValue, initialStone)
        {
            OwnerId = ownerId;
            _collector = collector;
            Position = (x, y);
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