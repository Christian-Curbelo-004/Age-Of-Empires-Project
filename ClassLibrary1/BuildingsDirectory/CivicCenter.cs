
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.MapDirectory;
using CreateBuildings;
using GameModels;

namespace ClassLibrary1.BuildingsDirectory                    //  CivicCenterNamespace
{
    public class CivicCenter : IMapEntity
    {
        public int OwnerId { get; set; }
        public int Speed { get; } = 0; // El Civic Center no se mueve, por lo que su velocidad es 0
        public (int X, int Y) Position { get; set; }
        public const int maxhealth = 100;
        public int actualhealth = 100;
        private bool isbuilded = false;
        private IMapEntity _mapEntityImplementation;
        public const int capacity = 100;
    }
}
