using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.BuildingsDirectory;

public class Home : Buildings , ICapacity, IMapEntity
{
    public int OwnerID { get; set; }
    public string Symbol { get; set; } = "Ho";
    public override string ToString()
    {
        return $"{Symbol}{OwnerId}"; 
    }
    public int Capacity => 5; // Capacidad de la casa
    public string EntityType => "Home";  // Entidad
    public Home(int endurence, int constructiontimeleft, string name, int ownerId)
        : base(endurence, name) 
    {
        ConstructionTime = constructiontimeleft;
        OwnerID = ownerId;
    }
}