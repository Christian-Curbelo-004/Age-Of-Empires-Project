using CreateBuildings;
using System;

namespace ChivarlyCenter
{
    public class ChivarlyCenter : Buildings
    {
        public ChivarlyCenter(int endurence, int constructionspeed, string name, int resourcevalue, int capacity)
            : base(endurence, constructionspeed, name, resourcevalue, capacity)
        {
        }

        public int ResourceBuildChC(int resourceValue)
        {
            return resourceValue;
        }
    }
}
