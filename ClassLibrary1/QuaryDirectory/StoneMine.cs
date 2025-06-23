// using System;

using System;

namespace ClassLibrary1.QuaryDirectory;

public class StoneMine : Quary
{
    public StoneMine(int collectiontimeleft, int collectionvalue, string collectiontype, int stone)
        : base(collectiontimeleft, collectionvalue, collectiontype)
    {
        Stone = stone;
    }

    public int Stone { get; set; }

    public override int GetResources()
    {
        int gather = base.GetResources(); 
        if (Stone >= gather)
        {
            Stone -= gather;
            CollectionValue += gather;
            Console.WriteLine($"Se han recolectado {gather} unidades de madera. Madera restante: {Stone}");
            return gather;
        }
        {
            // Console.WriteLine("No hay suficiente madera para recolectar.");
            return 0;
        }
    }
}