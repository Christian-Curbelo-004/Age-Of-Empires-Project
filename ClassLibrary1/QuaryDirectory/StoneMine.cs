// using System;

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
        int recolectado = base.GetResources(); 
        if (Stone >= recolectado)
        {
            Stone -= recolectado; 
            Console.WriteLine($"Se han recolectado {recolectado} unidades de piedra. Piedra restante: {Stone}");
            return recolectado;
        }
        else
        {
            Console.WriteLine("No hay suficiente piedra para recolectar.");
            return 0;
        }
    }
}