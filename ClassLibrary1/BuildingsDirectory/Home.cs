using CreateBuildings;
using System;
using System.Collections.Generic;

namespace HomeBuilding
{
    public class HomeBuilding : Buildings
    {
        public HomeBuilding(int endurence, int constructionspeed, string name, int resourcevalue, int capacity)
            : base(endurence, constructionspeed, name, resourcevalue, capacity)
        {
        }
        public void GetConstructionCost(Dictionary<string, int> ConstructionCost)
        {
            ConstructionCost["Piedra"] = 20;
            ConstructionCost["Madera"] = 100;
        }
        public void IncreasePoblation(int resourceValue)
        {
        }
    }
}