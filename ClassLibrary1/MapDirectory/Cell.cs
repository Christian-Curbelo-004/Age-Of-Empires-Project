using ClassLibrary1.MapDirectory;

namespace ClassLibrary1
{
    public class Cell 
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public bool IsOccupied { get; set; }
        public string EntityType { get; set; }

        public IMapEntity Entity { get; set; }
        public IResource Resource { get; set; }

        public Cell(int x, int y)
        {
            PosX = x;
            PosY = y;
            IsOccupied = false;
        }
    }
}