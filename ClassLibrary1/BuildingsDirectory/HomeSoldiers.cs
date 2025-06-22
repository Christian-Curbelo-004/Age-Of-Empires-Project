using CreateBuildings;

namespace ClassLibrary1.BuildingsDirectory;
using GameModels;

public class HomeSoldiers : Buildings
{
    public const int PopulationIncrease = 5;

    public HomeSoldiers(int endurence, int constructiontimeleft, string name)
        : base(endurence, constructiontimeleft, name) 
    {
    }
    public override void GetConstructionCost()
    {
        ConstructionCost[GameResourceType.Food] = 30;
        ConstructionCost[GameResourceType.Stone] = 20;
    }
}
