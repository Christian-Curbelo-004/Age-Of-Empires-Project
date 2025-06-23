using System.Collections.Generic;
using GameResourceType = GameModels.GameResourceType;
namespace CreateBuildings
{
    public abstract class Buildings
    {
        
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Endurence { get; set; }
        public Buildings(int endurence, string name)
        {
            Endurence = endurence;
            Name = name;
            
        }
        
    }
}