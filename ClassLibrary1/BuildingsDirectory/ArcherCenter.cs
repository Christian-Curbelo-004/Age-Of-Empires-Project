using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.BuildingsDirectory
{
    /// <summary>
    /// Edificio de entrenamiento de los arqueros.
    /// </summary>
    public class ArcherCenter : Buildings, ITrainingBuilding
    {
        /// <summary>
        ///  ID del jugador que tiene el archer center.
        /// </summary>
        public int OwnerId { get; set; }
        public string Symbol { get; set; } = "AC";
        public override string ToString()
        {
            return $"{Symbol}{OwnerId}"; 
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ArcherCenter"/> con los atributos heredados.
        /// </summary>
        /// <param name="endurence">Resistencia inicial del edificio.</param>
        /// <param name="constructiontimeleft">Tiempo restante de construcción del edificio.</param>
        /// <param name="name">Nombre del edificio.</param>
        /// <param name="ownerId">ID del jugador propietario.</param>
        public ArcherCenter(int endurence, int constructiontimeleft, string name, int ownerId)
            : base(endurence, name)
        {
            OwnerId = ownerId;
            ConstructionTime = constructiontimeleft;
        }

        /// <summary>
        /// Crea una unidad de tipo "archer" si el tipo es válido.
        /// </summary>
        /// <param name="troopType">Tipo de unidad a crear (solo se permite "archer").</param>
        /// <returns>Una nueva unidad de tipo arquero.</returns>
        /// <exception cref="InvalidOperationException"> si el tipo de unidad no es compatible con este edificio.</exception>
        public IMapEntity CreateUnit(string troopType)
        {
            if (troopType.Equals("archer", StringComparison.OrdinalIgnoreCase))
            {
                return new Archer
                {
                    OwnerId = this.OwnerId,
                    Position = this.Position
                };
            }

            throw new InvalidOperationException($"'{troopType}' no se puede crear en ArcherCenter.");
        }
    }
}
