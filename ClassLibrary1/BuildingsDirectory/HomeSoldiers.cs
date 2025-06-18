using CreateBuildings;
using System.Collections.Generic;
namespace ClassLibrary1.BuildingsDirectory;

public class HomeSoldiers : Buildings
    {
        public HomeSoldiers(int endurence, int constructiontimeleft, string name, int resourcevalue)
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
