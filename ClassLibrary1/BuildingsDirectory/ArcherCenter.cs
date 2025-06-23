using CreateBuildings;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.LogicDirectory;
using GameModels;

namespace ClassLibrary1.BuildingsDirectory
{   
    public class ArcherCenter : Buildings, IMapEntity
    {
        public int OwnerId { get; set; }
        public ArcherCenter(int endurence, int constructiontimeleft,  string name, int ownerId)
            : base(endurence, name)
        {
            OwnerId = ownerId;
        }
        
    }
}