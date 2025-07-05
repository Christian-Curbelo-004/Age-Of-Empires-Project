namespace ClassLibrary1.QuaryDirectory
{
    public class Forest : Quary
    {
        public int OwnerId { get; set; }
        private readonly IResourceCollector _collector; //Uso interfaces para cumplir con DIP
        public int CurrentAmount
        {
            get => Wood;
            set => Wood = value;
        }

        public string ResourceType => "Wood";
        public int Wood { get; private set; }
        public Forest(int ownerId, int extractionRate, int collectionValue, int initialWood, IResourceCollector collector) 
            : base(ownerId, extractionRate, collectionValue,initialWood )
        {
            OwnerId = ownerId;
            _collector = collector;
            CurrentAmount = initialWood;
        }
        public int GetResources(int collectors) 
        {
            int collected = _collector.CalculateCollected(Wood, ExtractionRate, collectors);
            Wood -= collected;
            return collected;
        }
    }
}