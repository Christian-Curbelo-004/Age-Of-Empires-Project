using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.LogicDirectory;
using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.Bonus;

public class GameState
{
    public string PlayerName { get; set; }
    public (int, int) Position { get; set; }
    public Dictionary<string, int> ResourceValue { get; set; } = new();
    public List<Buildings> Buildings { get; set; } = new();
    public List<IMapEntity> Units { get; set; } = new();
    public ResourceInventory Resources { get; set; }
}