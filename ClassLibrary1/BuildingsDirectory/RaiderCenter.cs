using CreateBuildings;

namespace ClassLibrary1.BuildingsDirectory;

public class RaiderCenter : Buildings
{
    public int OwnerId { get; set; } // Propiedad del jugador 

    public RaiderCenter(int endurence, int construciontimeleft, string name, int ownerId) : base(endurence, name)
    {
        OwnerId = ownerId;
    }

    public async Task<RaiderCenter> CreateRaiderCenter()
    {
        await Task.Delay(1000);
        return this;
    }
}