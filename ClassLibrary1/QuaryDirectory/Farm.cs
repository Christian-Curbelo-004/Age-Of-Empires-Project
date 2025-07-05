

namespace ClassLibrary1.QuaryDirectory
{
    public class Farm : IResourceDeposit
    {
      //  public string Name { get; set; } = "Farm";
        public int OwnerId { get; set; }
        public int CurrentAmount
        {
            get => Food;
            set => Food = value;
        }
        
        public string ResourceType => "Food";
        public int Food { get; private set; }

        private int _extractionRate;
        private int _collectionValue;

        public Farm(int ownerId, int initialFood, int extractionRate, int collectionValue)
        {
            OwnerId = ownerId;
            Food = initialFood;
            _extractionRate = extractionRate;
            _collectionValue = collectionValue;
        }

        

        public int GetResources(int collectors)
        {
            int collected = GetResourcesCollected.ResourceCollected(Food, _extractionRate, collectors);
            Food -= collected;
            return collected;
        }
    }
}