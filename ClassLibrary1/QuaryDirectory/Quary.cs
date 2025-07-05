
using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;
// Posible cambio ya que no se usa
public  class Quary : IResourceDeposit, IMapEntity
{
    public int OwnerId { get; set; }
    public int Speed { get; set; }= 0;
    public (int X, int Y) Position { get; set; }
    public string Type { get; set; }
   public string Name { get; set; } = "Quary"; 

    public int ExtractionRate { get; set; }
    public int CollectionValue { get; set; }
    public int CurrentAmount { get;  set; }
    public string ResourceType { get;  set; }

    public Quary(int ownerId, int extractionRate, int collectionValue, int initialAmount, string resourceType)
    {
        OwnerId = ownerId;
        ExtractionRate = extractionRate;
        CollectionValue = collectionValue;
        CurrentAmount = initialAmount;
        ResourceType = resourceType;

    }

    public Quary()
    {
    }

    public virtual int GetResources(int collectors = 1)
    {
        return ExtractionRate * collectors;
    }
}