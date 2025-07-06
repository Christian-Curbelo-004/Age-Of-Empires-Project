namespace ClassLibrary1.BuildingsDirectory;

public class RaiderCenter : Buildings
{
    public int OwnerId { get; set; } // Propiedad del jugador 

    public RaiderCenter(int endurence, int construciontimeleft, string name, int ownerId) : base(endurence, name)
    {
        OwnerId = ownerId;
        ConstructionTime = construciontimeleft;
    }
}