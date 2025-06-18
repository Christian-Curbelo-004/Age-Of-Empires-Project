using CreateBuildings;
using System;
using System.Collections.Generic;
using ClassLibrary1;

namespace HomeVillagers
{
    public class HomeVillagers : Buildings
    {
        public HomeVillagers(int endurence, int constructiontimeleft, string name, int resourcevalue)
            : base(endurence : 30, constructiontimeleft : 15, name : "Home", resourcevalue)
        {
        }
        public void GetConstructionCost(Dictionary<string, int> ConstructionCost)
        {
            ConstructionCost["Piedra"] = 20;
            ConstructionCost["Madera"] = 100;
        }
        public int GetPopulation()
        {
            return 5;
        }
    }
}