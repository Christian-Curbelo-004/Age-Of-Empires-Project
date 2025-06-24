using ClassLibrary1.LogicDirectory;
using CreateBuildings;

namespace ClassLibrary1.BuildingsDirectory
{   
    public class ArcherCenter : Buildings
    {
        public int OwnerId { get; set; }
        public ArcherCenter(int endurence, int constructiontimeleft,  string name, int ownerId)
            : base(endurence, name)
        {
            OwnerId = ownerId;
        }
        public Cost GetCost()
        {
            return new Cost(0, 100, 10, 0);
        }
    }
}