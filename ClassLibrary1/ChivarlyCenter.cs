using CreateBuildings;
using System;

namespace ChivarlyCenter
{
    public class ChivarlyCenter : Buildings
    {
        public ChivarlyCenter(int endurence, int constructionspeed, string name, int resourcevalue, int capacity )
            : base(endurence, constructionspeed, name, resourcevalue, capacity)
        {
        }

        public int resourceBuildChC(int resourceValue)
        {
            return resourceValue;
        }
    }
}
