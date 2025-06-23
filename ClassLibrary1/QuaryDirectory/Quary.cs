using ClassLibrary1;
using ClassLibrary1.QuaryDirectory;

public abstract class Quary : IResourceDeposit, IMapEntity
{
    public int OwnerId { get; private set; }


    public int ExtractionRate { get; protected set; }
    public int CollectionValue { get; protected set; }
    public int CurrentAmount { get; protected set; }
    public string ResourceType { get; protected set; }

    protected Quary(int ownerId, int extractionRate, int collectionValue, int initialAmount, string resourceType)
    {
        OwnerId = ownerId;
        ExtractionRate = extractionRate;
        CollectionValue = collectionValue;
        CurrentAmount = initialAmount;
        ResourceType = resourceType;

    }

    public virtual int GetResources(int collectors = 1)
    {
        return ExtractionRate * collectors;
    }
}