using CreateBuildings;
namespace   ClassLibrary1.BuildingsDirectory                                   
{
    public class HomeVillagers : Buildings
    {
        public string EntityType => "HomeVillagers";
        public const int PopulationIncrease = 5;
        public int MaxVillagers { get; set; } = 10;
        public HomeVillagers(int endurence, int constructiontimeleft, string name)
            : base(endurence,  name)        
        {
        }
        
    }
}