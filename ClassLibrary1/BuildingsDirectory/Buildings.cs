using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.BuildingsDirectory
{
    public abstract class Buildings : IMapEntity
    {
        public int OwnerId { get; set; }
        public (int X, int Y) Position { get; set; }
        public string Name { get; set; }
       
       public int ConstructionTime { get; set; }
       public bool IsConstructed { get; set; } 
        public int Endurence { get; set; }
        public Buildings(int endurence, string name)
        {
            Endurence = endurence;
            Name = name;
            Position = (0, 0); 
        }
    }
}