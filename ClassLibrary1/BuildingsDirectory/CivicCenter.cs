using System;
using CreateBuildings;

namespace CivicCenter
{
    public class CivicCenter : Buildings 
    {
        public CivicCenter(int endurence, int constructionspeed,string name, int resourcevalue, int capacity)
            : base(endurence, constructionspeed, name, resourcevalue, capacity)
        {
        }
        public int resourceBuildCC(int resourceValue)
        {
            return resourceValue;
        }
        
    }
}