using System;


namespace ClassLibrary1.QuaryDirectory;

public class StoneMine : Quary
{
    public StoneMine(int collectionspeed, int collectionvalue, string collectiontype)
        : base(collectionspeed, collectionvalue,collectiontype)
    {
    }
    public int Stone { get; set; }



    public override int GetResources()
    {
        int recolectado = base.GetResources();
        return recolectado;
    }
    
}