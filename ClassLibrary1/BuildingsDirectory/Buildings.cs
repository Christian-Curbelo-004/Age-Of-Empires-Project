using System;
using System.Collections.Generic;

namespace CreateBuildings
{
    public abstract class Buildings
    {
        public string Name { get; set; }
        public int Endurence { get; set; }
        public int ConstructionTimeLeft { get; set; }
        public int ResourceValue { get; set; }
        private Dictionary<string, int> ConstructionCost = new Dictionary<string, int>();
        public Buildings(int endurence, int constructiontimeleft, string name, int resourceValue)
        {
            Endurence = endurence;
            ConstructionTimeLeft = constructiontimeleft;
            Name = name;
            ResourceValue = resourceValue;
        }
        public void GetConstructionCost(Dictionary<string,int>ConstruccionCost)
        {
        }
    }
}