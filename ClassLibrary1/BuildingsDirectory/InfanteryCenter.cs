using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.LogicDirectory;
using CreateBuildings;

namespace ClassLibrary1.BuildingsDirectory //InfanteryCenter (lo comento por si genera problemas ClassLibrary1.BuildingsDirectory) ClassLibrary1.BuildingsDirectory

{
    public class InfanteryCenter : Buildings
    {
        public int OwnerId { get; set; }
        public InfanteryCenter(int endurence, int constructiontimeleft, string name, int ownerId)
            : base(endurence, name)
        {
            OwnerId = ownerId;
        }
    }
}
