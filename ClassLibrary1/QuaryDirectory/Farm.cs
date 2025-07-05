using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.QuaryDirectory
{
    public class Farm 
    {
        public string Name { get; set; } = "Farm";
        public int OwnerId { get; set; }
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
<<<<<<< Updated upstream
        public int GetResources(int collectors = 1)
=======
        public int GetResources(int collectors)
>>>>>>> Stashed changes
        {
            int collected = GetResourcesCollected.ResourceCollected(Food, _extractionRate, collectors);
            Food -= collected;
            return collected;
        }
    }
}