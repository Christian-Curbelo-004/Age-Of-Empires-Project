using System;
using System.Collections.Generic;
using CreateBuildings;
using GameModels;

namespace CivicCenterNamespace
{
    public class CivicCenter : Buildings
    {
        public int MaxVillagers {get; private set;} = 3;
        public int MaxSoldiers {get; private set;} = 0;
        public int CurrentVillagers {get; private set;} = 3;
        public int CurrentSoldiers {get; private set;} = 0;
        public CivicCenter(int endurence, int constructiontimeleft, string name)
            : base(endurence : 50, constructiontimeleft : 30, name : "CivicCenter")
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
    }
}