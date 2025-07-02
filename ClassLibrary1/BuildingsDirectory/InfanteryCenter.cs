using CreateBuildings;
namespace ClassLibrary1.BuildingsDirectory
{
    public class InfanteryCenter : Buildings
    {
            public Dictionary<string, int> GetConstructionCost()
            {
                return new Dictionary<string, int>
                {
                    { "Piedra", 10 },
                    { "Oro", 20 }
                };
            }
        
        public int OwnerId { get; set; } // Propiedad del jugador 
        public InfanteryCenter(int endurence, int constructiontimeleft, string name, int ownerId)
            : base(endurence, name)
        {
            OwnerId = ownerId;
        }
    }
}
