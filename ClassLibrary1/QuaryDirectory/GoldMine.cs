
namespace ClassLibrary1.QuaryDirectory
{
    public class GoldMine : Quary
    {
        public int OwnerId { get; set; }
        private readonly IResourceCollector _collector; 
        public int CurrentAmount
        {
            get => Gold;
            set => Gold = value;
        }

        public int Gold { get; private set; }
        public string ResourceType => "Gold";
        

        public GoldMine(int ownerId, int extractionRate, int collectionValue, int initialGold, IResourceCollector collector) 
            : base(ownerId, extractionRate, collectionValue,initialGold )
        {
            OwnerId = ownerId;
            _collector = collector;
            CurrentAmount = initialGold;
        }
        
        public int GetResources(int collectors)
        {
            int collected = _collector.CalculateCollected(Gold, ExtractionRate, collectors);
            Gold -= collected;
            return collected;
        }
    }
}