using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1
{
    /// <summary>
    /// Representa una celda del mapa que puede contener entidades y recursos.
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// establece la posición X de la celda.
        /// </summary>
        public int PosX { get; set; }

        /// <summary>
        /// establece la posición Y de la celda.
        /// </summary>
        public int PosY { get; set; }

        /// <summary>
        /// Lista de entidades presentes en esta celda.
        /// </summary>
        public List<IMapEntity> Entities { get; } = new List<IMapEntity>();

        /// <summary>
        /// Indica si la celda está ocupada por alguien/algo.
        /// </summary>
        public bool IsOccupied => Entities.Count > 0;

        /// <summary>
        /// Obtiene los nombres de los tipos de las entidades contenidas en la celda.
        /// </summary>
        public IEnumerable<string> EntityTypes => Entities.Select(e => e.GetType().Name);

        /// <summary>
        ///  establece la entidad principal de la celda.
        /// </summary>
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

        /// <summary>
        /// Recurso presente en la celda .
        /// </summary>
        public IResourceDeposit Resource { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Cell"/> en las coordenadas dadas.
        /// </summary>
        /// <param name="x">Posición X de la celda.</param>
        /// <param name="y">Posición Y de la celda.</param>
        public Cell(int x, int y)
        {
            PosX = x;
            PosY = y;
            Resource = null;
        }

        /// <summary>
        /// Agrega una entidad a la lista de entidades en esta celda,
        /// si no está ya presente para evitar duplicados.
        /// </summary>
        /// <param name="entity">Entidad a agregar.</param>
        public void AddEntity(IMapEntity entity)
        {
            if (!Entities.Contains(entity))
                Entities.Add(entity);
        }
    }
}
