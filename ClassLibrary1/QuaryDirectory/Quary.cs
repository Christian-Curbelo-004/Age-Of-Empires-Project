using System;

namespace ClassLibrary1.QuaryDirectory
{
    public abstract class Quary : IResourceDeposit, IMapEntidad
    {
        public int ExtractionRate { get; protected set; } // unidades por ciclo
        public int CollectionValue { get; protected set; } // acumulado total
        public int RemainingResource { get; protected set; } // cantidad restante

        public string ResourceType { get; protected set; } // tipo: oro, piedra, comida, etc.

        // Nombre visible en el mapa
        public string Name { get; set; }

        public string EntityType => ResourceType;

        protected Quary(int extractionRate, int collectionValue, int initialResource, string resourceType)
        {
            ExtractionRate = extractionRate;
            CollectionValue = collectionValue;
            RemainingResource = initialResource;
            ResourceType = resourceType;
        }

        public virtual int GetResources(int collectors = 1)
        {
            if (RemainingResource <= 0)
            {
                return 0;
            }

            int amount = Math.Min(ExtractionRate * collectors, RemainingResource);
            RemainingResource -= amount;
            CollectionValue += amount;

            return amount;
        }
    }
}