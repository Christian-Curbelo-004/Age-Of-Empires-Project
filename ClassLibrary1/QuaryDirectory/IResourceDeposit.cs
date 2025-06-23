namespace ClassLibrary1.QuaryDirectory
{
    public interface IResourceDeposit
    {
        int GetResources(int collectors = 1);
        string ResourceType { get; }
    }
}