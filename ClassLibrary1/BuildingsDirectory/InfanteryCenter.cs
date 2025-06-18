using System;
using System.Collections.Generic;
using CreateBuildings;

namespace InfanteryCenter
{
    public class InfanteryCenter : Buildings
    {
        public InfanteryCenter(int endurence, int constructiontimeleft, string name, int resourcevalue)
            : base(endurence:20, constructiontimeleft:10, name:"InfanteryCenter", resourcevalue)
        {
        }
        public void GetConstructionCost(Dictionary<string, int> ConstructionCost)
        {
            ConstructionCost["Piedra"] = 10;
            ConstructionCost["Oro"] = 6;
        }
    }
}
