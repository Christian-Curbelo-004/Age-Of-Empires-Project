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
    public List<Units> Units { get; set; } = new();
    public int MaxPoblacion { get; set; }
    public int CurrentPoblacion => Units.Count;
    public (int, int) StartingPosition { get; set; }
    public CivicCenter CivicCenter { get; set; }

    public Player(int id, string civilization, int maxPoblacion)
    {
        Id = id;
        Civilization = civilization;
        CivicCenter = new CivicCenter();
        MaxPoblacion = maxPoblacion;
      
    }
    public void AddUnit(Units unit)
    {
        if (CurrentPoblacion < MaxPoblacion)
        {
            Units.Add(unit);
        }
    }
    
}