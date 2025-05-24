using System;

namespace CreateBuildings
{
    public abstract class Buildings
    {
        public int Endurence { get; set; }
        public int ConstructionSpeed { get; set; }

        // Constructor
        public Buildings(int endurence, int constructionspeed)
        {
            Endurence = endurence;
            ConstructionSpeed = constructionspeed;
        }
        // Metodo
        public abstract void Build(int resourceValue);
    }
}