using CreateBuildings;
using System;

namespace ChivarlyCenter
{
    public class ChivarlyCenter : Buildings
    {
        
        public ChivarlyCenter(int endurence, int constructionspeed, string name, int resourcevalue, int capacity)
            : base(endurence, constructionspeed, name, resourcevalue, capacity)
        {
        }

        public void GetconstructionCost(Dictionary<string,int>ConstruccionCost)
        {
            ConstruccionCost["Madera"] = 100;
            ConstruccionCost["Oro"] = 20;
        }
        public int GetConstuctionTime(int ConstructionTime)
        {
            ConstructionTime = 20;
            return ConstructionTime;
        }
    }
}
