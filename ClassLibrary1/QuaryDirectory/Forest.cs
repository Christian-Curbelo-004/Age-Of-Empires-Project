using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;

public class Forest : Quary, IMapEntity
{
    public int OwnerId { get; set; }
    public (int X, int Y) Position { get; set; }
    public string Name { get; set; } = "Forest";

    private readonly IResourceCollector _collector;
    public int CurrentAmount
    {
        get => Wood;
        set => Wood = value;
    }

    public string ResourceType => "Wood";
    public int Wood { get; private set; }

    public Forest(int x, int y, int initialWood, int extractionRate, int collectionValue, int ownerId, IResourceCollector collector)
        : base(ownerId, extractionRate, collectionValue, initialWood)
    {
        OwnerId = ownerId;
        _collector = collector;
        Position = (x, y);
        CurrentAmount = initialWood;
    }

    public int GetResources(int collectors)
    {
        int collected = _collector.CalculateCollected(Wood, ExtractionRate, collectors);
        Wood -= collected;
        return collected;
    }
}