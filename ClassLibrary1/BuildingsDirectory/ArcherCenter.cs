using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.BuildingsDirectory
{   
    public class ArcherCenter : Buildings, ITrainingBuilding
    {
        public int OwnerId { get; set; }

        public ArcherCenter(int endurence, int constructiontimeleft, string name, int ownerId)
            : base(endurence, name)
        {
            OwnerId = ownerId;
            ConstructionTime = constructiontimeleft;
        }

        public IMapEntity CreateUnit(string troopType)
        {
            if (troopType.Equals("archer", StringComparison.OrdinalIgnoreCase))
            {
                return new Archer
                {
                    OwnerId = this.OwnerId,
                    Position = this.Position 
                };
            }

            throw new InvalidOperationException($"'{troopType}' no se puede crear en ArcherCenter.");
        }
    }
}