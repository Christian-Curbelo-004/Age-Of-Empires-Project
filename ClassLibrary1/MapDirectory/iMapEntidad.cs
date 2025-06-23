namespace ClassLibrary1
{
    public interface IMapEntity
    {
        int OwnerId { get; }

    }

    public interface IResource : IMapEntity
    {
        int Collect(int workers);
    }
}