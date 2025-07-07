using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.UnitsDirectory
{
    public abstract class GameUnit : IMapEntity
    {
        public string  Name { get; set; }
        public int OwnerId { get; set; }
        public (int X, int Y) Position { get; set; }
    }
}