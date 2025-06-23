namespace ClassLibrary1
{
    public class Quary : IMapEntidad
    {
        public int ExtractionRate { get; set; } //cantidad por tiempo
        public int CollectionValue { get; set; }  //total de lo recolectado
        
        public string CollectionType { get; set; } //para ver que material esta colectando

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


        public virtual int GetResources()
        {
            int amount = ExtractionRate;
            CollectionValue += ExtractionRate;
            return amount; //para ver lo que se recolecto, sin ver lo que ya podia haber de antes
        }

        public void collect()
        {
            CollectionValue += ExtractionRate;
        }
    }
}
