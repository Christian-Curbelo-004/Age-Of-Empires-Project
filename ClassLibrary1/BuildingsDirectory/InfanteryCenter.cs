using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.BuildingsDirectory 
    
  
{
    public class InfanteryCenter : Buildings, IMapEntity
    {
        public string Symbol { get; set; } = "IC";
        public override string ToString()
        {
            return $"{Symbol}{OwnerId}"; 
        }
        public new int OwnerId { get; set; } 
        public InfanteryCenter(int endurence, int constructiontimeleft, string name, int ownerId)
            : base(endurence, name)
        {
            OwnerId = ownerId;
            ConstructionTime =  constructiontimeleft;
        }
    }
}
