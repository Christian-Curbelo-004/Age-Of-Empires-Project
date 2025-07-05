namespace ClassLibrary1.QuaryDirectory;

public interface IResourceCollector
{
    int CalculateCollected(int available, int extractionRate, int collectors);
}