using CreateBuildings;

namespace ClassLibrary1.BuildingsDirectory;
using GameModels;

public class HomeSoldiers : Buildings,IMapEntidad
{
    public const int PopulationIncrease = 5;
    public string EntityType => "HomeVillagers";
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
