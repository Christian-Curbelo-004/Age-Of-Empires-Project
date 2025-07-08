using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.BuildingsDirectory
{
    /// <summary>
    /// Clase abstracta que representa un edificio en el mapa.
    /// </summary>
    public abstract class Buildings : IMapEntity
    {
        /// <summary>
        /// ID del jugador que construyo el edificio.
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Obtiene o establece la posición del edificio en el mapa, como coordenadas X e Y.
        /// </summary>
        public (int X, int Y) Position { get; set; }
        public string Symbol { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del edificio.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece el tiempo restante de construcción del edificio.
        /// </summary>
        public int ConstructionTime { get; set; }

        /// <summary>
        /// Indica si el edificio ya fue construido completamente.
        /// </summary>
        public bool IsConstructed { get; set; }

        /// <summary>
        /// Obtiene o establece la resistencia (durabilidad) del edificio.
        /// </summary>
        public int Endurence { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Buildings"/> con la resistencia y el nombre especificados.
        /// </summary>
        /// <param name="endurence">Resistencia inicial del edificio.</param>
        /// <param name="name">Nombre del edificio.</param>
        public Buildings(int endurence, string name)
        {
            // Asignamos la resistencia inicial y el nombre del edificio
            Endurence = endurence;

            Name = name;

            // Inicializamos la posición en (0, 0) por defecto
            Position = (0, 0);
        }
    }
}