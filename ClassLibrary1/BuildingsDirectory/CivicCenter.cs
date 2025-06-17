using System;
using System.Collections.Generic;
using CreateBuildings;

namespace CivicCenterNamespace
{
    public class CivicCenter : Buildings
    {
        public CivicCenter(int endurence, int constructionspeed, string name, int resourceValue, int capacity)
            : base(endurence, constructionspeed, name, resourceValue, capacity)
        {
        }
        public void GetConstructionCost(Dictionary<string, int> ConstructionCost)
        {
            ConstructionCost["Madera"] = 140;
            ConstructionCost["Oro"] = 6;
            ConstructionCost["Piedra"] = 10;
        }
        
        public bool TieneCapacidad(int unidades, int capacity)          //para ver si tiene capacidad para agregar mas unidades
        {
            if (unidades < capacity)
            {
                return true;
            }

            return false;
        }
    }
}