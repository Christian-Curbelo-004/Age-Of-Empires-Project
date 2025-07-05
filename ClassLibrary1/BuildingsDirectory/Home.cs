using CreateBuildings;

namespace ClassLibrary1.BuildingsDirectory;

public class Home : Buildings , ICapacity
{
    public int Capacity { get; } = 5; // Capacidad de la casa
    public string EntityType => "Home";  // Entidad
    public Home(int endurence, int constructiontimeleft, string name)
        : base(endurence, name) 
    {
        ConstructionTime = constructiontimeleft;
    }
    
}