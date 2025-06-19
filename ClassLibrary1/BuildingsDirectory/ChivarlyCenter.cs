using CreateBuildings;
using System;
using System.Collections.Generic;
using GameModels;
namespace ChivarlyCenter
{
    public class ChivarlyCenter : Buildings
    {
        
        public ChivarlyCenter(int endurence, int constructiontimeleft, string name)
            : base(endurence:20, constructiontimeleft:10, name: "ChivalryCenter")
        {
        }
        public override void SetConstructionCost()
        {
            ConstructionCost[GameResourceType.Stone] = 170;
            ConstructionCost[GameResourceType.Wood] = 100;
        }
    }
}
 
 