namespace ClassLibrary1.MapDirectory
{
    public interface IMapEntity
    {
        string Symbol { get; set; }
        int OwnerId { get; set; }
        (int X, int Y) Position { get; set; }
    }

    public interface IResource : IMapEntity
    {
        int Collect(int workers);
    }
}