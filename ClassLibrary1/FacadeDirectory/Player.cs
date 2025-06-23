using GameResourceType = GameModels.GameResourceType;
using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.DepositDirectory;
using ClassLibrary1.CivilizationDirectory;
namespace ClassLibrary1.FacadeDirectory;

public class Player
{
    public int Id { get; set; }


    public Player(int id)
    {
        Id = id;
    }
}