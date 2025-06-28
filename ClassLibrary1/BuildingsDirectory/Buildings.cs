//using ClassLibrary1.LogicDirectory;
using ClassLibrary1.MapDirectory;

namespace CreateBuildings
{
    public abstract class Buildings : IMapEntity
    {
        public int OwnerId { get; set; }
        public (int X, int Y) Position { get; set; }
        public string Name { get; set; }
        public int Speed { get; } = 0; // Buildings typically do not move, so speed is set to 0
        public int Endurence { get; set; }
        public Buildings(int endurence, string name)
        {
            Endurence = endurence;
            Name = name;
            OwnerId = OwnerId;
            Position = (0, 0); // Default position, can be changed later
            Speed = 0;
            //  Capacity = capacity;
        }

        protected Buildings() {}
        
    }
}