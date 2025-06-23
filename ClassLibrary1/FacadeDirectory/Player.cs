using GameResourceType = GameModels.GameResourceType;
using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.DepositDirectory;
using ClassLibrary1.CivilizationDirectory;
namespace ClassLibrary1.FacadeDirectory;

public class Player
{
    public Dictionary<GameResourceType, int> Resources { get; private set; }
    public int Food { get; set; } = 0;
    public int Wood { get; set; } = 0;
    public int Id { get; private set; }
    public string Name { get; private set; }
    public Civilization Civilization { get; private set; }
    public List<Deposit> Deposits { get; set; } = new();
    public List<Villagers> Villagers { get; private set; }
    public List<Soldier> Soldiers { get; private set; }
    public List<Quary> Quaries { get; private set; }
    public CivicCenter CivicCenter { get; set; }
    public Player(string name, Civilization civilization)
    {
        Name = name;
        Id = Id;
        Civilization = civilization;
        Villagers = new List<Villagers>();
        Soldiers = new List<Soldier>();
        CivicCenter = null;
        Quaries = new List<Quary>();
        
        Resources = new Dictionary<GameResourceType, int> 
        {
            { GameResourceType.Food, 0 },
            { GameResourceType.Wood, 0 },
            { GameResourceType.Gold, 0 },
            { GameResourceType.Stone, 0 }
        };
    }
    public void AddVillagers(Villagers villagers)
    {
        Villagers.Add(villagers);
    }

    public bool HasResources(Dictionary<GameResourceType, int> Resources)
    {
        foreach (var item in Resources)
        {
            if (!Resources.ContainsKey(item.Key) || Resources[item.Key] < item.Value)
            {
                return false;
            }
        }
        return true;
    }

    public void SpendResources(Dictionary<GameResourceType, int> ConstructionCost)
    {
        foreach (var item in ConstructionCost)
        {
            if (Resources.ContainsKey(item.Key))
            {
                ConstructionCost[item.Key] -= item.Value;
            }
        }
    }

    public Deposit GetAvailableDeposit(GameResourceType type)
    {
        foreach (var d in Deposits)
        {
            if (d.ResourceType == type && d.CurrentStorage < d.MaxCapacity)
                return d;
        }
        return null;
    }  
    public void AddSoldier(Soldier soldier)
    {
        Soldiers.Add(soldier);
    }

    public int GetVillagerCount()
    {
        return Villagers.Count;
    }

    public int GetSoldierCount()
    {
        return Soldiers.Count;
    }

    public Villagers GetFirstVillagerFree()
    {
        Villagers villager = new Villagers(100,15, 1);
        foreach (var V in Villagers)
        {
            if (villager.IsFree)
                return villager;
        }
        return null;
    }

    public void AddQuary(Quary quary)
    {
        Quaries.Add(quary);
    }
}
