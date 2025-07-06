using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.BuildingsDirectory
{
    public class RaiderCenter : Buildings, ITrainingBuilding
    {
        public int OwnerId { get; set; }

        public RaiderCenter(int endurence, int constructiontimeleft, string name, int ownerId)
            : base(endurence, name)
        {
            OwnerId = ownerId;
            ConstructionTime = constructiontimeleft;
        }

        public IMapEntity CreateUnit(string troopType)
        {
            if (troopType.Equals("raider", StringComparison.OrdinalIgnoreCase))
            {
                return new Raider { OwnerId = this.OwnerId, Position = this.Position };
            }

            throw new InvalidOperationException($"'{troopType}' no se puede crear en RaiderCenter.");
        }
    }
}