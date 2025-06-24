using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.DepositDirectory;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.MapDirectory;
using ClassLibrary1.UnitsDirectory;

namespace ClassLibrary1.FacadeDirectory;

public class Player
{
    public int Id { get; set; }
    public string Civilization { get; set; }
    public object Buildings { get; set; }
    public object Units { get; set; }
    public (int, int) StartingPosition { get; set; }
    public CivicCenter CivicCenter { get; set; }

    public Player(int id)
    {
        Id = id;
        Civilization = "Civilization";
    }
    public Player(int id, string civilization)
        {
        Id = id;
        Civilization = civilization;
        
        }

    public void AddUnit(Villagers villager)
    {
        
    }

    public void AddSoldier(bool newSoldier)
    {
        throw new NotImplementedException();
    }

    public object GetAvailableDeposit(object resourceType)
    {
        throw new NotImplementedException();
    }
}