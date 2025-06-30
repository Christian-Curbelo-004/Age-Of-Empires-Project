using CreateBuildings;

namespace ClassLibrary1.BuildingsDirectory;

public class CenturiesCenter : Buildings
{
    public int OwnerId { get; set; }

    public CenturiesCenter(int endurence, int constructiontimeleft, string name, int ownerId) : base(endurence, name)
    {
        OwnerId = ownerId;
    }
}