using CreateBuildings;
using System;
using System.Collections.Generic;
using ClassLibrary1.CivilizationDirectory;
using GameModels;
namespace ChivarlyCenter
{
    public class ChivarlyCenter : Buildings
    {
        
        public ChivarlyCenter(int endurence, int constructiontimeleft, string name)
            : base(endurence:20, constructiontimeleft:10, name: "ChivalryCenter")
        {
        }
        public override void SetConstructionCost()
        {
            ConstructionCost[GameResourceType.Stone] = 170;
            ConstructionCost[GameResourceType.Wood] = 100;
        }

        public void CreateChivarly()
        {
            Chivarly chivarly = new Chivarly()
            {
                Life = 100,
                AttackValue = 20,
                DeffenseValue = 15,
                Speed = 20,
            };
        }
    }
}
 
 