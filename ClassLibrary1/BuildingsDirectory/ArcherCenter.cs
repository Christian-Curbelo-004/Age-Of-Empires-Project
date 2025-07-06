namespace ClassLibrary1.BuildingsDirectory
{   
    public class ArcherCenter : Buildings
    {
        public int OwnerId { get; set; } // Propiedad del jugador 
        public ArcherCenter(int endurence, int constructiontimeleft,  string name, int ownerId)
            : base(endurence, name)
        {
            OwnerId = ownerId;
            ConstructionTime = constructiontimeleft;
        }
    }
}