namespace ClassLibrary1.MapDirectory
{
    public interface IMapEntity
    {
        int OwnerId { get; }
        (int X, int Y) Position { get; set; } 

    }

    public interface IResource : IMapEntity
    {
        int Collect(int workers);
    }
}