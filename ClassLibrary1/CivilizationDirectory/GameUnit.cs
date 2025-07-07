using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.UnitsDirectory
{
    /// <summary>
    /// Clase base abstracta para unidades del juego que pueden ubicarse en el mapa.
    /// </summary>
    public abstract class GameUnit : IMapEntity
    {
        /// <summary>
        /// Obtiene o establece el nombre de la unidad.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece el ID del jugador propietario de la unidad.
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Obtiene o establece la posición de la unidad en el mapa (coordenadas X, Y).
        /// </summary>
        public (int X, int Y) Position { get; set; }
    }
}