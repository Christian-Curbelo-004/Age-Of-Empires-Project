using ClassLibrary1.CivilizationDirectory;
using CreateBuildings;
using GameModels;

namespace ClassLibrary1.BuildingsDirectory                    //  CivicCenterNamespace
{
    public class CivicCenter : Buildings, IMapEntidad
    {
        public int MaxVillagers { get; private set; } = 3;
        public int MaxSoldiers { get; private set; } = 1;
        public int CurrentVillagers { get; set; } = 3;
        public int CurrentSoldiers { get; set; }

        public CivicCenter(int endurence, int constructiontimeleft, string name)
            : base(endurence, constructiontimeleft, name)   // endurence: 50, constructiontimeleft: 30, name: "CivicCenter"
        {
        }

        public void AddHomeVillagersCapacity()
        {
            MaxVillagers = Math.Min(MaxVillagers + HomeVillagers.PopulationIncrease,20);
        }

        public void AddHomeSoldiersCapacity()
        {
            MaxSoldiers += Math.Min(MaxVillagers + HomeVillagers.PopulationIncrease, 30);
        }

        public bool CanCreateVillagers()
        {
            return (CurrentVillagers < MaxVillagers);
        }

        public bool CanCreateSoldiers()
        {
            return (CurrentSoldiers < MaxSoldiers);
        }

        public override void GetConstructionCost()
        {
            ConstructionCost[GameResourceType.Stone] = 100;
            ConstructionCost[GameResourceType.Gold] = 40;
            ConstructionCost[GameResourceType.Wood] = 150;
        }

        public Villagers CreateVillagers()
        {
            if (!CanCreateVillagers()) return null;
            CurrentVillagers++;
            return new Villagers(100,5);
        }

        public Soldier CreateSoldier(Soldier soldier)
        {
            CurrentSoldiers++;
            return soldier;
        }
        public string EntityType { get; }
    }
}