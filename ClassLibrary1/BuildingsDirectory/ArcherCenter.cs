using System;
using CreateBuildings;

namespace ArcherCenter
{
    public class ArcherCenter : Buildings
    {
        public ArcherCenter(int endurence, int constructiontimeleft, int capacity, string name, int resourcevalue)
            : base(endurence:20, constructiontimeleft:10, name:"ArcherCenter", resourcevalue, capacity:5)
        {
        }
        public int resourceBuildAC(int resourceValue)
        {
            return resourceValue;
        }
    }
}