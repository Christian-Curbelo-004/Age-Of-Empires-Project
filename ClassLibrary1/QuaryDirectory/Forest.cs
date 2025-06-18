using System;
using ClassLibrary1;

namespace QuaryBiome
{
    public class Forest : Quary
    {
        public Forest(int collectiontimeleft, int collectionvalue, string collectiontype)
            : base(collectiontimeleft, collectionvalue, collectiontype)
        {
        }

        public int Wood { get; set; }
        public override int GetResources()
        {
            int recolectado = base.GetResources(); //llamar al metodo desde la clase Quary, no este
            return recolectado;
        }
        
    }
}
