
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.MapDirectory;
using CreateBuildings;
using GameModels;

namespace ClassLibrary1.BuildingsDirectory                    //  CivicCenterNamespace
{
    public class CivicCenter : IMapEntity
    {
        public int OwnerId { get; set; }
        public (int X, int Y) Position { get; set; }
        public const int maxhealth = 100;
        public int actualhealth = 100;
        private bool isbuilded = false;
        public const int capacity = 100;
    }
}
