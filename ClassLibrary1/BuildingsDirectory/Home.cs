using CreateBuildings;
using System;

namespace HomeBuilding
{
    public class HomeBuilding : Buildings
    {
        public HomeBuilding(int endurence, int constructionspeed, string name, int resourcevalue, int capacity)
            : base(endurence, constructionspeed, name, resourcevalue, capacity)
        {
        }
        public int resourceBuildHome(int resourceValue)
        {
            return resourceValue;
        }
        
    }
}