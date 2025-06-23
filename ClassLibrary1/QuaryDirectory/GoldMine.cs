
namespace ClassLibrary1.QuaryDirectory;

public class GoldMine : Quary
{
    public GoldMine(int collectiontimeleft, int collectionvalue, string collectiontype, int gold)
        : base(collectiontimeleft, collectionvalue, collectiontype)
    {
        Gold = gold; 
    }

    public int Gold { get; set; } 

    public override int GetResources()
    {
        int gather = base.GetResources(); 
        if (Gold >= gather)
        {
            Gold -= gather;
            CollectionValue += gather;
            Console.WriteLine($"Se han recolectado {gather} unidades de madera. Madera restante: {Gold}");
            return gather;
        }
        {
            // Console.WriteLine("No hay suficiente madera para recolectar.");
            return 0;
        }
    }
}