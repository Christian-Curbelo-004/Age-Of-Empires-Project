//using System;
//using System.Collections.Generic;
//using ClassLibrary1;
using CreateBuildings;
using GameModels;

namespace ClassLibrary1.BuildingsDirectory                    //  CivicCenterNamespace
{
    public class CivicCenter : Buildings, IMapEntidad
    {
        public int MaxVillagers { get; private set; } = 3;
        public int MaxSoldiers { get; private set; } = 1;
        public int CurrentVillagers { get; private set; } = 3;
        public int CurrentSoldiers { get; private set; } = 0;

        public CivicCenter(int endurence, int constructiontimeleft, string name)
            : base(endurence, constructiontimeleft, name)   // endurence: 50, constructiontimeleft: 30, name: "CivicCenter"
        {
        }

        public void AddHomeVillagersCapacity()
        {
            MaxVillagers += 5;
        }

        public void AddHomeSoldiersCapacity()
        {
            MaxSoldiers += 5;
        }

        public bool CanCreateVillagers()
        {
            return (CurrentVillagers < MaxVillagers);
        }

        public bool CanCreateSoldiers()
        {
            return (CurrentSoldiers < MaxSoldiers);
        }

        public override void SetConstructionCost()
        {
            ConstructionCost[GameResourceType.Stone] = 100;
            ConstructionCost[GameResourceType.Gold] = 40;
            ConstructionCost[GameResourceType.Wood] = 150;
        }

        public Villagers CreateVillagers()
        {
            Villagers villager = new Villagers(100, 5);
            return villager;
        }

        public string EntityType { get; }
    }
}