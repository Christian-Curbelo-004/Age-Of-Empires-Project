using System;
using System.Collections.Generic;
using CreateBuildings;

namespace CivicCenterNamespace
{
    public class CivicCenter : Buildings
    {
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