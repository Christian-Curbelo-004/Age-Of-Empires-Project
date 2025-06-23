using ClassLibrary1.LogicDirectory;
using CreateBuildings;
using GameModels;

namespace ClassLibrary1.CivilizationDirectory
{
    public class ChivarlyCenter : Buildings, IMapEntidad
    {
        public int OwnerId { get; set; }
        public ChivarlyCenter(int endurence, int constructiontimeleft,  string name, int ownerId)
            : base(endurence, constructiontimeleft, name) 
        {
            OwnerId = ownerId;
        }
        public override void GetConstructionCost()
        {
            ConstructionCost[GameResourceType.Stone] = 170;
            ConstructionCost[GameResourceType.Wood] = 100;
        }

        public Chivarly  CreateChivarly()
        {
            return UnitFactory.CreateChivarly();
        }
        public string EntityType => "ChivarlyCenter";

    }
}
 
 