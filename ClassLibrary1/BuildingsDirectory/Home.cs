using CreateBuildings;

namespace ClassLibrary1.BuildingsDirectory;

public class Home : Buildings
{
    public const int PopulationIncrease = 5;
    public string EntityType => "Home";
    public Home(int endurence, int constructiontimeleft, string name)
        : base(endurence, name) 
    {
    }
}