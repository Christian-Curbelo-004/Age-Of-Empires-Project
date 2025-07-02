using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1
{
    public class Cell
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public List<IMapEntity> Entities { get; } = new List<IMapEntity>();
        public bool IsOccupied => Entities.Count > 0;
        public IEnumerable<string> EntityTypes => Entities.Select(e => e.GetType().Name);
        public IMapEntity Entity
        {
            get => Entities.FirstOrDefault();
            set
            {
                Entities.Clear();
                if (value != null)
                    Entities.Add(value);
            }
        }

        public IResourceDeposit Resource { get; set; }

        public Cell(int x, int y)
        {
            PosX = x;
            PosY = y;
            Resource = null;
        }
    }
}