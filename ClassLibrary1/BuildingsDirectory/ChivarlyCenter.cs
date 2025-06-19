using CreateBuildings;
using System;
using System.Collections.Generic;

namespace ChivarlyCenter
{
    public class ChivarlyCenter : Buildings
    {
        
        public ChivarlyCenter(int endurence, int constructiontimeleft, string name, int resourcevalue)
            : base(endurence:20, constructiontimeleft:10, name: "ChivalryCenter", resourcevalue)
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
 
 