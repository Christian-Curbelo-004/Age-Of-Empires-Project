using CreateBuildings;

namespace ClassLibrary1.BuildingsDirectory;

public class CenturiesCenter : Buildings
{
    public int OwnerId { get; set; } // Propiedad del jugador 
    

    public CenturiesCenter(int endurence, int constructiontimeleft, string name, int ownerId) : base(endurence, name)
    {
        OwnerId = ownerId;
        ConstructionTime = constructiontimeleft;
    }
    public async Task <CenturiesCenter> Build()
    {
        await Task.Delay(1000);
        return this;
    }
}