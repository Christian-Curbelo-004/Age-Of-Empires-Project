using CreateBuildings;

namespace ClassLibrary1.BuildingsDirectory;
using GameModels;

public class HomeSoldiers : Buildings
{
    public const int PopulationIncrease = 5;
    public string EntityType => "HomeVillagers";
    public HomeSoldiers(int endurence, int constructiontimeleft, string name)
        : base(endurence, name) 
    {
    }
    
}
