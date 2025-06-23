namespace ClassLibrary1.QuaryDirectory;

public class GoldMine : Quary
{
    public GoldMine(int collectiontimeleft, int collectionvalue, string collectiontype, int gold)
        : base(collectiontimeleft, collectionvalue, collectiontype)
    {
        Gold = gold; 
    }

    public int Gold { get; set; } 

    public override int GetResources(int collectors = 1)
    {
        int amount = base.GetResources(collectors);
        Console.WriteLine($"Se recolectaron {amount} unidades");
        return amount;
    }
}