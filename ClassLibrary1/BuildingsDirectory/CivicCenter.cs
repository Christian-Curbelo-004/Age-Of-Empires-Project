using ClassLibrary1.LogicDirectory;
using ClassLibrary1.MapDirectory;
using CreateBuildings;

namespace ClassLibrary1.BuildingsDirectory;                  
    public class CivicCenter : Buildings , IMapEntity , ICapacity
    {
        public int OwnerId { get; set; }
      //  public int Speed { get; } = 0; // El Civic Center no se mueve, por lo que su velocidad es 0
        public (int X, int Y) Position { get; set; }
        public const int MaxHealth = 500;
        public int ActualHealth = 500;
        private bool isbuilded = false;
        private IMapEntity _mapEntityImplementation;
        public int Capacity { get; } = 10;
        
    }

