using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;

namespace ClassLibrary1
{
    public class Cell
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public bool IsOccupied { get; set; }
        public string EntityType { get; set; }

        public IMapEntity Entity { get; set; }
        public IResourceDeposit Resource { get; set; }

        public Cell(int x, int y)
        {
            PosX = x;
            PosY = y;
            IsOccupied = false;
            EntityType = null;
            Entity = null;
            Resource = null;
        }
    }
}