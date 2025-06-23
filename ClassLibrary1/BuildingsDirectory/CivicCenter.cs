
using ClassLibrary1.CivilizationDirectory;
using CreateBuildings;
using GameModels;

namespace ClassLibrary1.BuildingsDirectory                    //  CivicCenterNamespace
{
    public class CivicCenter : Buildings, IMapEntidad
    {
       public int Health { get; set; }
        public int MaxVillagers { get; private set; } = 10;
        public int OwnerId { get; set; } 
        public int MaxSoldiers { get; private set; } = 0;
        public int CurrentVillagers { get; set; } = 3;
        public int CurrentSoldiers { get; set; }

        public CivicCenter(int endurence, int constructiontimeleft, string name, int ownerId)
            : base(endurence, constructiontimeleft, name)
        {
            OwnerId = ownerId;
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
            return new Villagers(100,5,1);
        }

        public Soldier CreateSoldier(Soldier soldier)
        {
            CurrentSoldiers++;
            return soldier;
        }
        public string EntityType => "CivicCenter";  
    }
}