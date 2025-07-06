using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.MapDirectory;
using ClassLibrary1.CivilizationDirectory.CharactersDirectory;

namespace ClassLibrary1.BuildingsDirectory
{
    public class InfanteryCenter : Buildings, ITrainingBuilding
    {
        public new int OwnerId { get; set; }

        public InfanteryCenter(int endurence, int constructiontimeleft, string name, int ownerId)
            : base(endurence, name)
        {
            OwnerId = ownerId;
            ConstructionTime = constructiontimeleft;
        }

        public IMapEntity CreateUnit(string troopType)
        {
            if (troopType.Equals("infantwry", StringComparison.OrdinalIgnoreCase))
            {
                return new Infantery { OwnerId = this.OwnerId, Position = this.Position };
            }

            throw new InvalidOperationException($"'{troopType}' no se puede crear en InfanteryCenter.");
        }
    }
}
