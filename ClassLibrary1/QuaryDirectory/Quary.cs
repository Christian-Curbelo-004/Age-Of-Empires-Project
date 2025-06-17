namespace ClassLibrary1
{
    public class Quary
    {
        public int CollectionSpeed { get; set; } //cantidad por tiempo
        public int CollectionValue { get; set; }  //total de lo recolectado
        
        public string CollectionType { get; set; } //para ver que material esta colectando

        public Quary(int collectionspeed,int collectionValue, string collectionType)
        {
            CollectionSpeed = collectionspeed;
            CollectionValue = collectionValue;
            CollectionType = collectionType;
        }


        public virtual int GetResources()
        {
            CollectionValue += CollectionSpeed;
            return CollectionSpeed; //para ver lo que se recolecto, sin ver lo que ya podia haber de antes
            
        }
        public void Collect()
        {
            CollectionValue += CollectionSpeed;   //suma al total de lo recolectado, la cantidad que recolecta por tiempo
             
        }
    }
}
