//using System;
using CreateBuildings;
//using System.Collections.Generic;
using GameResourceType = GameModels.GameResourceType;
namespace   ClassLibrary1.BuildingsDirectory                                   // HomeVillagers
{
    public class HomeVillagers : Buildings
    {
        public const int PopulationIncrease = 5;
        public HomeVillagers(int endurence, int constructiontimeleft, string name)
            : base(endurence, constructiontimeleft, name)        // endurence : 30, constructiontimeleft : 15, name : "Home"
        {
        }
        public override void SetConstructionCost()
        {
            ConstructionCost[GameResourceType.Food] = 30;
            ConstructionCost[GameResourceType.Stone] = 20;
        }
    }
}