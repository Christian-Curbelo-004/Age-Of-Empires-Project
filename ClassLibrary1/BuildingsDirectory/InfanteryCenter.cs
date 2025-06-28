using CreateBuildings;
using ClassLibrary1.LogicDirectory;

namespace ClassLibrary1.BuildingsDirectory
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
