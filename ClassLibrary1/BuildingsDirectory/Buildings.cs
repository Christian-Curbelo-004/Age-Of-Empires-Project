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
        public int Capacity { get; set; }
        private Dictionary<string, int> ConstructionCost = new Dictionary<string, int>();
        public Buildings(int endurence, int constructiontimeleft, string name, int resourceValue, int capacity)
        {
            Endurence = endurence;
            ConstructionTimeLeft = constructiontimeleft;
            Name = name;
            ResourceValue = resourceValue;
            Capacity = capacity;
        }
        public void GetConstructionCost(Dictionary<string,int>ConstruccionCost)
        {
        }
    }
}