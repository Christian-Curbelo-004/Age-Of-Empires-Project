using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;

public class GoldMine : Quary, IMapEntity
{
    public int OwnerId { get; set; }
    public (int X, int Y) Position { get; set; }
    public string Name { get; set; } = "Gold Mine";

    private readonly IResourceCollector _collector;
    public int CurrentAmount
    {
        get => Gold;
        set => Gold = value;
    }

    public int Gold { get; private set; }
    public string ResourceType => "Gold";

    public GoldMine(int x, int y, int initialGold, int extractionRate, int collectionValue, int ownerId, IResourceCollector collector)
        : base(ownerId, extractionRate, collectionValue, initialGold)
    {
        OwnerId = ownerId;
        _collector = collector;
        Position = (x, y);
        CurrentAmount = initialGold;
    }

    public int GetResources(int collectors)
    {
        int collected = _collector.CalculateCollected(Gold, ExtractionRate, collectors);
        Gold -= collected;
        return collected;
    }
}