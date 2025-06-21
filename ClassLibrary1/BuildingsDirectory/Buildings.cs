using GameResourceType = GameModels.GameResourceType;
namespace CreateBuildings
{
    public abstract class Buildings
    {
        
        public string Name { get; set; }
        public int Endurence { get; set; }
        public int ConstructionTimeLeft { get; set; }
        public Dictionary<GameResourceType, int> ConstructionCost { get;  set; } = new ();
        public Buildings(int endurence, int constructiontimeleft, string name)
        {
            Endurence = endurence;
            ConstructionTimeLeft = constructiontimeleft;
            Name = name;
        }
        public abstract void SetConstructionCost();
    }
}