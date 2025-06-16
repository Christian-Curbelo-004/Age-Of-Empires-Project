using System.Collections.Generic;
using CivicCenterNamespace;
namespace ClassLibrary1;

public class PlayerOne
{
    public string Name { get; private set; }
    public Civilization Civilization { get; private set; }
    public List<Villagers> Villagers { get; private set; }
    public List<Soldier> Soldiers { get; private set; }
    public CivicCenter CivicCenter { get; set; }

    public PlayerOne(string name, Civilization civilization)
    {
        Name = name;
        Civilization = civilization;
        Villagers = new List<Villagers>();
        Soldiers = new List<Soldier>();
        CivicCenter = null; 
    }

    public class ResourceInventory
    {
        public int Food { get; set; }
        public int Wood { get; set; }
        public int Gold { get; set; }
        public int Stone { get; set; }
    }
    public void AddVillagers(Villagers villagers)
    {
        Villagers.Add(villagers);
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
}