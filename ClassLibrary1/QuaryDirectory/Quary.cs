
// Posible cambio ya que no se usa
public abstract class Quary 
{
    public int OwnerId { get; set; }
   public string Name { get; set; } = "Quary"; 

    public int ExtractionRate { get; set; }
    public int CollectionValue { get; set; }
    public int CurrentAmount { get;  set; }

    public Quary(int ownerId, int extractionRate, int collectionValue, int initialAmount)
    {
        OwnerId = ownerId;
        ExtractionRate = extractionRate;
        CollectionValue = collectionValue;
        CurrentAmount = initialAmount;
    }
    public virtual int GetResources(int collectors)
    {
        return ExtractionRate * collectors;
    }
}