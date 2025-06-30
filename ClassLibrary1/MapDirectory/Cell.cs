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

        // Lista de entidades en la celda (para múltiples entidades)
        public List<IMapEntity> Entities { get; } = new List<IMapEntity>();

        // True si hay al menos una entidad
        public bool IsOccupied => Entities.Count > 0;

        // Para obtener todos los tipos de entidades en la celda
        public IEnumerable<string> EntityTypes => Entities.Select(e => e.GetType().Name);

        // Mantener propiedad Entity para compatibilidad:
        // accede a la primera entidad o setea una única entidad (reemplazando la lista)
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