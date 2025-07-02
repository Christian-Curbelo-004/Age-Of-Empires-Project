using CreateBuildings;

namespace ClassLibrary1.CivilizationDirectory
{
    public class ChivarlyCenter : Buildings
    {
        public int OwnerId { get; set; } // Propiedad del jugador 
        public ChivarlyCenter(int endurence, int constructiontimeleft,  string name, int ownerId)
            : base(endurence,  name) 
        {
            OwnerId = ownerId;
            ConstructionTime = constructiontimeleft;
        }

        public async Task<ChivarlyCenter> BuildChivarlyCenter()
        {
            await Task.Delay(1000);
            return this;
        }
    }
}
 
 