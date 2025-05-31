using System; 

namespace CreateBuildings
{
    public abstract class Buildings
    {
        public string Name { get; set; }
        public int Endurence { get; set; }
        public int ConstructionSpeed { get; set; }

        
        public Buildings(int endurence, int constructionspeed)
        {
            Endurence = endurence;
            ConstructionSpeed = constructionspeed;
        }
        
        public abstract void Build(int resourceValue);
    }
}