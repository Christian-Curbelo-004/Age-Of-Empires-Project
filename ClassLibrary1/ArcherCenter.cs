using System;
using CreateBuildings;

namespace ArcherCenter
{
    public class ArcherCenter : Buildings
    {
        public ArcherCenter(int endurence, int constructionspeed, int capacity, string name, int resourcevalue)
            : base(endurence, constructionspeed, name, resourcevalue, capacity)
        {
        }
        public int resourceBuildAC(int resourceValue)
        {
            return resourceValue;
        }
    }
}