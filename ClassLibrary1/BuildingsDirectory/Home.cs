using CreateBuildings;
using System;
using System.Collections.Generic;
using ClassLibrary1;

namespace Home
{
    public class Home : Buildings
    {
        public int MaxVillagers = 20;
        public int MaxSoldiers = 30;
        public Home(int endurence, int constructiontimeleft, string name, int resourcevalue)
            : base(endurence : 30, constructiontimeleft : 15, name : "Home", resourcevalue)
        {
        }
        
        public void GetConstructionCost(Dictionary<string, int> ConstructionCost)
        {
            ConstructionCost["Piedra"] = 20;
            ConstructionCost["Madera"] = 100;
        }
        
        public bool HasCapacity(int units, int capacity)          //para ver si tiene capacidad para agregar mas unidades
        {
            if (units < capacity)
            {
                return true;
            }
            return false;
        }
        public int CreateVillagers(int units, int capacity)
        {
            if (HasCapacity(units, capacity))
            {
                units += 1;
                return units;
            }
            else
            {
                return 0;
            }
        }
        
    }
}