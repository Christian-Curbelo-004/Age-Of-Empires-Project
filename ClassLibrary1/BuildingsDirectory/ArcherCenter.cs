using System;
using CreateBuildings;
using ClassLibrary1.CivilizationDirectory;
using System.Collections.Generic;
using GameModels;

namespace ArcherCenter
{
    public class ArcherCenter : Buildings
    {
        public ArcherCenter(int endurence, int constructiontimeleft, string name)
            : base(endurence:20, constructiontimeleft:10, name:"ArcherCenter")
        {
        }
        public override void SetConstructionCost()
        {
            ConstructionCost[GameResourceType.Stone] = 170;
            ConstructionCost[GameResourceType.Wood] = 100;
        }

        public void CreateArcher()
        {
        }
    }
}