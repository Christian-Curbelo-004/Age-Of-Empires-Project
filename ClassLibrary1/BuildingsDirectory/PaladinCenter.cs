using CreateBuildings;

namespace ClassLibrary1.BuildingsDirectory;

public class PaladinCenter : Buildings
{
    public int OwnerId { get; set; }

    public PaladinCenter(int endurence, int constructiontimeleft, string name, int ownerId) : base(endurence, name)
    {
        OwnerId = ownerId;
    }
}