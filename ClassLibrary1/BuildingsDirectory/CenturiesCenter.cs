using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.MapDirectory;


namespace ClassLibrary1.BuildingsDirectory
{
    public class CenturiesCenter : Buildings, ITrainingBuilding
    {
        public int OwnerId { get; set; }
        public string Symbol { get; set; } = "CeC";
        public CenturiesCenter(int endurence, int constructiontimeleft, string name, int ownerId)
            : base(endurence, name)
        {
            OwnerId = ownerId;
            ConstructionTime = constructiontimeleft;
        }

        public IMapEntity CreateUnit(string troopType)
        {
            if (troopType.Equals("centurion", StringComparison.OrdinalIgnoreCase))
            {
                return new Centuries { OwnerId = this.OwnerId, Position = this.Position };
            }

            throw new InvalidOperationException($"'{troopType}' no se puede crear en CenturiesCenter.");
        }
    }
}