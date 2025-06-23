namespace ClassLibrary1
{
    public class Quary : IMapEntidad
    {
        public int ExtractionRate { get; set; } //cantidad por tiempo
        public int CollectionValue { get; set; }  //total de lo recolectado
        public int RemainingResource { get; set; }
        
        public string CollectionType { get; set; } //para ver que material esta colectando

        public string Name { get; set; }

        public string EntityType
        {
            get {return CollectionType;}
        }

        public Quary(int extractionRate,int collectionValue, string collectionType)
        {
            ExtractionRate = extractionRate;
            CollectionValue = collectionValue;
            CollectionType = collectionType;
            
        }


        public virtual int GetResources(int collectors = 1)
        {
            int amount = Math.Min(ExtractionRate * collectors, RemainingResource);
            RemainingResource -= amount;
            CollectionValue += amount;
            return amount; 
        }

        public void collect()
        {
            CollectionValue += ExtractionRate;
        }
    }
}
