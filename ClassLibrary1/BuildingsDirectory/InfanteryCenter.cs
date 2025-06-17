using System;
using System.Collections.Generic;
using CreateBuildings;

namespace InfanteryCenter
{
    public class InfanteryCenter : Buildings
    {
        public InfanteryCenter(int endurence, int constructiontimeleft, string name, int resourcevalue, int capacity)
            : base(endurence:20, constructiontimeleft:10, name:"InfanteryCenter", resourcevalue, capacity:5)
        {
        }
        public void GetConstructionCost(Dictionary<string, int> ConstructionCost)
        {
            ConstructionCost["Piedra"] = 10;
            ConstructionCost["Oro"] = 6;
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
