using CreateBuildings;
using System.Collections.Generic;


namespace ClassLibrary1.BuildingsDirectory;
using GameModels;

public class HomeSoldiers : Buildings
{
    public const int PopulationIncrease = 5;

    public HomeSoldiers(int endurence, int constructiontimeleft, string name)
        : base(endurence: 30, constructiontimeleft: 15, name: "Home")
    {
    }
    public override void SetConstructionCost()
    {
        ConstructionCost[GameResourceType.Food] = 30;
        ConstructionCost[GameResourceType.Stone] = 20;
    }
    
}
