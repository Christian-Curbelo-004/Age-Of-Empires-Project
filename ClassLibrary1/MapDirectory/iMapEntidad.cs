namespace ClassLibrary1.MapDirectory
{
    public interface IMapEntity
    {
        string Name { get; set; }
        int OwnerId { get; set; }
        (int X, int Y) Position { get; set; }
      //  int Speed { get; } // Si no se mueve, poner Speed = 0 en la clase concreta
    }

    public interface IResource : IMapEntity
    {
        int Collect(int workers);
    }
}