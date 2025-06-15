using System;


namespace ClassLibrary1.QuaryDirectory;

public class StoneMine : Quary
{
    public StoneMine(int collectionspeed, int collectionvalue)
        : base(collectionspeed, collectionvalue)
    {
    }
    public int Stone { get; set; }

    public void GetResources(int amount)
    {
        Stone = amount;
        Console.WriteLine(CollectionSpeed);
        Console.WriteLine(CollectionValue);
        Console.WriteLine($"Se recolecto {Stone} de oro");
    }
}