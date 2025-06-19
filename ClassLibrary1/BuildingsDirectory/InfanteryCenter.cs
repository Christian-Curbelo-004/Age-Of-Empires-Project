using System;
using ClassLibrary1.CivilizationDirectory;
using CreateBuildings;
using GameResourceType = GameModels.GameResourceType;


namespace InfanteryCenter
{
    public class InfanteryCenter : Buildings
    {
        public int ConstructionTime = 20;
        public const int CostStone = 40;
        public const int CostGold = 15;
        public InfanteryCenter(int endurence, int constructiontimeleft, string name)
            : base(endurence:20, constructiontimeleft:10, name:"InfanteryCenter")
        {
        }
        public override void SetConstructionCost()
        {
            ConstructionCost[GameResourceType.Food] = 30;
            ConstructionCost[GameResourceType.Stone] = 20;
        }

        public void CreateInfantery()
        {
        }
    }
}
