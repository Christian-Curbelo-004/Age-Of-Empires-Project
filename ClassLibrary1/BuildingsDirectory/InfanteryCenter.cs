using System;
using System.Collections.Generic;
using CreateBuildings;

namespace InfanteryCenter
{
    public class InfanteryCenter : Buildings
    {
        public InfanteryCenter(int endurence, int constructionspeed, string name, int resourcevalue, int capacity)
            : base(endurence, constructionspeed, name, resourcevalue, capacity)
        {
        }

        public void GetConstructionCost(Dictionary<string, int> ConstructionCost)
        {
            ConstructionCost["Piedra"] = 10;
            ConstructionCost["Oro"] = 6;
        }
        
    }
}