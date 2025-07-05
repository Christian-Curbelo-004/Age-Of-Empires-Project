
namespace ClassLibrary1.QuaryDirectory
{
    // Porque no heredamos de Quary
    public class GoldMine //: IResourceDeposit // IMapEntity
    {
        public int OwnerId { get; set; }
      //  public string Name { get; set; } = "Gold Mine";
        
      //public (int X, int Y) Position { get; set; }
        //public int Speed { get; set; } = 0; 
        public int CurrentAmount
        {
            get => Gold;
            set => Gold = value;
        }

        public int Gold { get; private set; }
        public string ResourceType => "Gold";

        private int _extractionRate;
        private int _collectionValue;

        public GoldMine(int ownerId, int initialGold, int extractionRate, int collectionValue)
        {
            OwnerId = ownerId;
            Gold = initialGold;
            _extractionRate = extractionRate;
            _collectionValue = collectionValue;
        }
        // Usar en clase GetResources
        public int GetResources(int collectors)
        {
            int collected = GetResourcesCollected.ResourceCollected(Gold, _extractionRate, collectors);
            Gold -= collected;
            return collected;
        }
    }
}