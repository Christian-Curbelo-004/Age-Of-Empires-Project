namespace ClassLibrary1.QuaryDirectory
{
    // Porque no heredamos de quary
    public class StoneMine 
    {
        public string Name { get; set; } = "Stone Mine"; 
        public int OwnerId { get; set; }
        public int CurrentAmount
        {
            get => Stone;
            set => Stone = value;
        }

        public int Stone { get; private set; }
        public string ResourceType => "Stone";

        private int _extractionRate;
        private int _collectionValue;

        public StoneMine(int ownerId, int initialStone, int extractionRate, int collectionValue)
        {
            OwnerId = ownerId;
            Stone = initialStone;
            _extractionRate = extractionRate;
            _collectionValue = collectionValue;
        }

        public int GetResources(int collectors = 1)
        {
            if (Stone <= 0) return 0;
            int amount = _extractionRate * collectors;
            int collected = Math.Min(Stone, amount);
            Stone -= collected;
            return collected;
        }
    }
}