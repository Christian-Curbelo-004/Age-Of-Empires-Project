namespace ClassLibrary1.QuaryDirectory
{
    public class Forest : IResourceDeposit // IMapEntity
    {
        public string Name { get; set; } = "Forest"; 
        public int OwnerId { get; set; }
        //public (int X, int Y) Position { get; set; }
        //public int Speed { get; set; } = 0; 
        public int CurrentAmount
        {
            get => Wood;
            set => Wood = value;
        }

        public int Wood { get; private set; }
        public string ResourceType => "Wood";

        private int _extractionRate;
        private int _collectionValue;

        public Forest(int ownerId, int initialWood, int extractionRate, int collectionValue)
        {
            OwnerId = ownerId;
            Wood = initialWood;
            _extractionRate = extractionRate;
            _collectionValue = collectionValue;
        }
        // Usar en clase GetResources
        public int GetResources(int collectors = 1)
        {
            if (Wood <= 0) return 0;
            int amount = _extractionRate * collectors;
            int collected = Math.Min(Wood, amount);
            Wood -= collected;
            return collected;
        }
    }
}