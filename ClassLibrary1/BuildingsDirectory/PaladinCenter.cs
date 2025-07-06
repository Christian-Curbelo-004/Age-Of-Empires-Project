using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.MapDirectory;
using ClassLibrary1.CivilizationDirectory.CharactersDirectory;

namespace ClassLibrary1.BuildingsDirectory
{
    public class PaladinCenter : Buildings, ITrainingBuilding
    {
        public int OwnerId { get; set; }

        public PaladinCenter(int endurence, int constructiontimeleft, string name, int ownerId)
            : base(endurence, name)
        {
            OwnerId = ownerId;
            ConstructionTime = constructiontimeleft;
        }

        public IMapEntity CreateUnit(string troopType)
        {
            if (troopType.Equals("paladin", StringComparison.OrdinalIgnoreCase))
            {
                return new Paladin { OwnerId = this.OwnerId, Position = this.Position };
            }

            throw new InvalidOperationException($"'{troopType}' no se puede crear en PaladinCenter.");
        }
    }
}