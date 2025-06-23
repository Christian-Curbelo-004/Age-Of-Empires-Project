using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.LogicDirectory;
using CreateBuildings;
using GameModels;


namespace ClassLibrary1.BuildingsDirectory //InfanteryCenter (lo comento por si genera problemas ClassLibrary1.BuildingsDirectory) ClassLibrary1.BuildingsDirectory

{
    public class InfanteryCenter : Buildings, IMapEntidad
    {
        public InfanteryCenter(int endurence, int constructiontimeleft, string name)
            : base(endurence, constructiontimeleft,name)
        {
        }
        public override void GetConstructionCost()
        {
            ConstructionCost[GameResourceType.Food] = 30;
            ConstructionCost[GameResourceType.Stone] = 20;
        }

        public  Infantery CreateInfantery()
        {
            return UnitFactory.CreateInfantery();
        }
        public string EntityType => "InfanteryCenter";

    }
}
