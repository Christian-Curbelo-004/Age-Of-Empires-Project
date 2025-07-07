using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;

public class Farm : Quary, IMapEntity
{
    public int OwnerId { get; set; }
    public (int X, int Y) Position { get; set; }
    public string Name { get; set; } = "Farm";

    private readonly IResourceCollector _collector;
    public override int CurrentAmount
    {
        get => Food;
        set => Food = value;
    }

    public override string ResourceType => "Food";
    public int Food { get; private set; }

    public Farm(int x, int y, int initialFood, int extractionRate, int collectionValue, int ownerId, IResourceCollector collector)
        : base(ownerId, extractionRate, collectionValue, initialFood)
    {
        OwnerId = ownerId;
        _collector = collector;
        Position = (x, y);
        CurrentAmount = initialFood;
    }

    public override int GetResources(int collectors)
    {
        int collected = _collector.CalculateCollected(Food, ExtractionRate, collectors);
        Food -= collected;
        return collected;
    }
}
