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

    public override int GetResources(int collectors = 1)
    {
        int amount = base.GetResources(collectors);
        Console.WriteLine($"Se recolectaron {amount} unidades");
        return amount;
    }
}