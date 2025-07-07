using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.MapDirectory;


namespace ClassLibrary1.BuildingsDirectory
{
    public class ChivarlyCenter : Buildings, ITrainingBuilding
    {
        public int OwnerId { get; set; }
        public string Symbol { get; set; } = "ChC";
        public ChivarlyCenter(int endurence, int constructiontimeleft, string name, int ownerId)
            : base(endurence, name)
        {
            OwnerId = ownerId;
            ConstructionTime = constructiontimeleft;
        }

        public IMapEntity CreateUnit(string troopType)
        {
            if (troopType.Equals("chivarly", StringComparison.OrdinalIgnoreCase))
            {
                return new Chivarly { OwnerId = this.OwnerId, Position = this.Position };
            }

            throw new InvalidOperationException($"'{troopType}' no se puede crear en ChivarlyCenter.");
        }
    }
}
 