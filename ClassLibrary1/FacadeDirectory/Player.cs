using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.MapDirectory;
using ClassLibrary1.UnitsDirectory;
using ClassLibrary1.LogicDirectory;
using CreateBuildings;


public class Player
{
    public int Id { get; set; }
    public string Civilization { get; set; }
    public List<Buildings> Buildings { get; set; } = new List<Buildings>();
    public List<IMapEntity> Units { get; set; } = new List<IMapEntity>();
    public int MaxPoblacion { get; set; }
    public int CurrentPoblacion => Units.Count;
    public (int, int) StartingPosition { get; set; }
    public CivicCenter CivicCenter { get; set; }
    public ResourceInventory Resources { get; set; } = new ResourceInventory();

    public Player(int id, string civilization, int maxPoblacion)
    {
        Id = id;
        Civilization = civilization;
        CivicCenter = new CivicCenter();
        MaxPoblacion = maxPoblacion;

        // Recursos iniciales
        Resources.Wood = 100;
        Resources.Food = 100;
        Resources.Gold = 0;
        Resources.Stone = 0;
    }

    public void AddUnit(Units unit)
    {
        if (CurrentPoblacion < MaxPoblacion)
        {
            Units.Add(unit);
        }
    }
}