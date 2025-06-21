using ClassLibrary1.LogicDirectory;
using CreateBuildings;
using GameModels;

namespace ClassLibrary1.CivilizationDirectory
{
    public class ChivarlyCenter : Buildings
    {
        
        public ChivarlyCenter(int endurence, int constructiontimeleft, string name)
            : base(endurence, constructiontimeleft, name) // endurence:20, constructiontimeleft:10, name: "ChivalryCenter"
        {
        }
        public override void SetConstructionCost()
        {
            ConstructionCost[GameResourceType.Stone] = 170;
            ConstructionCost[GameResourceType.Wood] = 100;
        }

        public Chivarly  CreateChivarly()
        {
            return UnitFactory.CreateChivarly();
        }
    }
}
 
 