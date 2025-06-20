//using System;
using ClassLibrary1.CivilizationDirectory;
using CreateBuildings;
using GameResourceType = GameModels.GameResourceType;


namespace ClassLibrary1.BuildingsDirectory //InfanteryCenter (lo comento por si genera problemas ClassLibrary1.BuildingsDirectory) ClassLibrary1.BuildingsDirectory

{
    public class InfanteryCenter : Buildings
    {
        public int ConstructionTime = 20;
        public const int CostStone = 40;
        public const int CostGold = 15;

        public InfanteryCenter(int endurence, int constructiontimeleft, string name)
            : base(endurence, constructiontimeleft, name)
        {
        }
        public override void SetConstructionCost()
        {
            ConstructionCost[GameResourceType.Food] = 30;
            ConstructionCost[GameResourceType.Stone] = 20;
        }

        public void CreateInfantery()
        {
            Infantery infantery = new Infantery()
            {
                Life = 100,
                AttackValue = 14,
                DeffenseValue = 10,
                Speed = 13,
            };
        }
    }
}
