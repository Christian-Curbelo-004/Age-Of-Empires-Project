using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.BuildingsDirectory;

public class Home : Buildings , ICapacity, IMapEntity
{
    public string Symbol { get; set; } = "Ho";
    public int Capacity => 5; // Capacidad de la casa
    public string EntityType => "Home";  // Entidad
    public Home(int endurence, int constructiontimeleft, string name)
        : base(endurence, name) 
    {
        ConstructionTime = constructiontimeleft;
    }
}