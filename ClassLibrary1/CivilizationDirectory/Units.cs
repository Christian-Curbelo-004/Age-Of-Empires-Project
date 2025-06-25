using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.UnitsDirectory
{
    public abstract class Units : IMapEntity
    {
        public string  Name { get; set; }
        public int OwnerId { get; set; }
        public (int X, int Y) Position { get; set; }

        // Comunes a todas las unidades
        public int Health { get; set; }
        public int Speed { get; set; }

        // Opcional: método virtual para mover, atacar, etc.
        public virtual void MoveTo(int x, int y)
        {
            Position = (x, y);
        }
    }
}