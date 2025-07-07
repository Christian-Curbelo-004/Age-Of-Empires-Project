
using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.BuildingsDirectory;

public class CivicCenter : Buildings, IMapEntity, ICapacity
{
    public string Symbol { get; set; } = "CC";
    public  int OwnerId { get; set; }

    //  public int Speed { get; } = 0; // El Civic Center no se mueve, por lo que su velocidad es 0
    public (int X, int Y) Position { get; set; }
    public const int MaxHealth = 500;
    public int ActualHealth = 500;
    private IMapEntity _mapEntityImplementation;
    public int Capacity => 10; // Capacidad del CC


    public CivicCenter(int endurance, int constructionTimeleft, string name, int ownerId) : base(endurance, name)
    {
        Endurence = endurance;
        OwnerId = ownerId;
        ConstructionTime = constructionTimeleft;
    }
}