using CreateBuildings;
namespace ClassLibrary1.BuildingsDirectory
{
    public class InfanteryCenter : Buildings
    {
        public int OwnerId { get; set; } // Propiedad del jugador 
        public InfanteryCenter(int endurence, int constructiontimeleft, string name, int ownerId)
            : base(endurence, name)
        {
            OwnerId = ownerId;
        }
    }
}
