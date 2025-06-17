using CreateBuildings;
using System;
using System.Collections.Generic;

namespace HomeBuilding
{
    public class HomeBuilding : Buildings
    {
        public HomeBuilding(int endurence, int constructiontimeleft, string name, int resourcevalue, int capacity)
            : base(endurence : 30, constructiontimeleft : 15, name : "Home", resourcevalue, capacity: 5)
        {
        }
        public void GetConstructionCost(Dictionary<string, int> ConstructionCost)
        {
            ConstructionCost["Piedra"] = 20;
            ConstructionCost["Madera"] = 100;
        }
        public bool HasCapacity(int unidades, int capacity)          //para ver si tiene capacidad para agregar mas unidades
        {
            if (unidades < capacity)
            {
                return true;
            }
            return false;
        }
    }
}