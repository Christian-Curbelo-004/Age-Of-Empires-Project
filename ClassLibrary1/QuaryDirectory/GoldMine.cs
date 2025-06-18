using System;

namespace ClassLibrary1.QuaryDirectory;

public class GoldMine : Quary
{
    public GoldMine(int collectiontimeleft, int collectionvalue, string collectiontype)
            : base(collectiontimeleft, collectionvalue, collectiontype)
        {
        }

        public int Gold { get; set; }

        public override int GetResources()
        {
            int recolectado = base.GetResources();
            return recolectado;
        }
        
}
