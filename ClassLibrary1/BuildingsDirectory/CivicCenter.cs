using System;
using CreateBuildings;

namespace CivicCenterNamespace
{
    public class CivicCenter : Buildings 
    {
        public CivicCenter(int endurence, int constructionspeed,string name, int resourceValue, int capacity)
            : base(endurence, constructionspeed, name, resourceValue, capacity)
        {
        }
        public int resourceBuildCC(int resourceValue)
        {
            return resourceValue;
        }
    }
}