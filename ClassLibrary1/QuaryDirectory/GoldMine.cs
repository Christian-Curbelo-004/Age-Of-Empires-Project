using System;

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
        int recolectado = base.GetResources(); 
        if (Gold >= recolectado)
        {
            Gold -= recolectado; 
            Console.WriteLine($"Se han recolectado {recolectado} unidades de oro. Oro restante: {Gold}");
            return recolectado;
        }
        else
        {
            Console.WriteLine("No hay suficiente oro para recolectar.");
            return 0;
        }
    }
}