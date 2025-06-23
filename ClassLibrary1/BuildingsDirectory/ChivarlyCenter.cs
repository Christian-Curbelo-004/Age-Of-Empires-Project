using ClassLibrary1.LogicDirectory;
using CreateBuildings;
using GameModels;

namespace ClassLibrary1.CivilizationDirectory
{
    public class ChivarlyCenter : Buildings
    {
        public int OwnerId { get; set; }
        public ChivarlyCenter(int endurence, int constructiontimeleft,  string name, int ownerId)
            : base(endurence,  name) 
        {
            OwnerId = ownerId;
        }

    }
}
 
 