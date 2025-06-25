using ClassLibrary1.LogicDirectory;
using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.BuildingsDirectory                    //  CivicCenterNamespace
{
    public class CivicCenter : IMapEntity
    {
        public int OwnerId { get; set; }
        public int Speed { get; } = 0; // El Civic Center no se mueve, por lo que su velocidad es 0
        public (int X, int Y) Position { get; set; }
        public const int MaxHealth = 100;
        public int Counter { get; set; }
        public int ActualHealth = 100;
        private bool isbuilded = false;
        private IMapEntity _mapEntityImplementation;
        public const int Capacity = 100;
        public Cost GetCost()
        {
            return new Cost(100, 120, 10, 0);
        }

        public int CivicCenterCount()
        {
            return Counter++;
        }
    }
}
