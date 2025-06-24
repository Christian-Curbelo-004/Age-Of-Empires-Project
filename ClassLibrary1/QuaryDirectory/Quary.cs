
using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;

public  class Quary : IResourceDeposit, IMapEntity
{
    public int OwnerId { get; set; }
    public int Speed { get; set; }= 0; // Quarries no se mueven, por lo que la velocidad es 0
    public (int X, int Y) Position { get; set; }
    public string Type { get; set; }
   

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
        throw new NotImplementedException();
    }

    public virtual int GetResources(int collectors = 1)
    {
        return ExtractionRate * collectors;
    }
}