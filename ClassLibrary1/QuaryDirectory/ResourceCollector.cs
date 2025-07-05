namespace ClassLibrary1.QuaryDirectory;

public class ResourceCollector : IResourceCollector
{
    public int CalculateCollected(int available, int extractionRate, int collectors)
    {
        int amount = extractionRate * collectors;
        return Math.Min(available, amount);
    }
}