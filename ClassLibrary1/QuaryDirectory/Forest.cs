namespace ClassLibrary1.QuaryDirectory
{
    public class Forest //: IResourceDeposit // IMapEntity
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

        public string ResourceType => "Wood";
        public int Wood { get; private set; }
        

        private int _extractionRate;
        private int _collectionValue;

        public Forest(int ownerId, int initialWood, int extractionRate, int collectionValue)
        {
            OwnerId = ownerId;
            Wood = initialWood;
            _extractionRate = extractionRate;
            _collectionValue = collectionValue;
        }
        public int GetResources(int collectors)
        {
            int collected = GetResourcesCollected.ResourceCollected(Wood, _extractionRate, collectors);
            Wood -= collected;
            return collected;
        }
    }
}