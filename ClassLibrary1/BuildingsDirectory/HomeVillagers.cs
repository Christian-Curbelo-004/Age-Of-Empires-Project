using CreateBuildings;
//using System.Collections.Generic;
using GameResourceType = GameModels.GameResourceType;
namespace   ClassLibrary1.BuildingsDirectory                                   
{
    public class HomeVillagers : Buildings
    {
        public const int PopulationIncrease = 5;
        public int MaxVillagers { get; set; } = 10;
        public HomeVillagers(int endurence, int constructiontimeleft, string name)
            : base(endurence, constructiontimeleft, name)        
        {
        }
        
        public override void SetConstructionCost()
        {
            ConstructionCost[GameResourceType.Food] = 30;
            ConstructionCost[GameResourceType.Stone] = 20;
        }
    }
}