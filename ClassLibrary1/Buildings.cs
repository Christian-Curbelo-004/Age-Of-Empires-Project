using System; 

namespace CreateBuildings
{
    public abstract class Buildings
    {
        public string Name { get; set; }
        public int Endurence { get; set; }
        public int ConstructionSpeed { get; set; }
        public int ResourceValue { get; set; }
        public int Capacity { get; set; }
        
    
        
        public Buildings(int endurence, int constructionspeed, string name, int resourceValue, int capacity)
        {
            Endurence = endurence;
            ConstructionSpeed = constructionspeed;
            Name = name;
            ResourceValue = resourceValue;
            Capacity = capacity;
        }
        
    }
}