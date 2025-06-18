using System;
using System.Collections.Generic;
using CreateBuildings;

namespace CivicCenterNamespace
{
    public class CivicCenter : Buildings
    {
        public int MaxVillagers = 3;
        public int MaxSoldiers = 0;
        public int CurrentVillagers = 3;
        public int CurrentSoldiers = 0;
        public CivicCenter(int endurence, int constructiontimeleft, string name, int resourceValue)
            : base(endurence : 50, constructiontimeleft : 30, name : "CivicCenter", resourceValue)
        {
        }
        public void GetConstructionCost(Dictionary<string, int> ConstructionCost) //Método para asignar el tipo de material y el valor de una construcción
        {
            ConstructionCost["Madera"] = 140;
            ConstructionCost["Oro"] = 6;
            ConstructionCost["Piedra"] = 10;
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
            if (CurrentVillagers < MaxVillagers)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CanCreateSoldiers()
        {
            if (CurrentSoldiers < MaxSoldiers)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}