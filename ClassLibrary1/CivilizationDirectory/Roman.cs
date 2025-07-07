using ClassLibrary1.CivilizationDirectory.CharactersDirectory;

namespace ClassLibrary1.CivilizationDirectory
{
    /// <summary>
    /// Representa la civilización romana con sus unidades específicas.
    /// </summary>
    public class Roman : Civilization
    {
        /// <summary>
        /// Inicializa una nueva instancia de la civilización romana y añade unidades iniciales.
        /// </summary>
        public Roman()
        {
            Units.Add(new Centuries());
        }

        /// <summary>
        /// Selecciona una unidad específica de la civilización romana según el nombre proporcionado.
        /// </summary>
        /// <param name="unitName">Nombre de la unidad a seleccionar.</param>
        /// <returns>La unidad correspondiente si existe; de lo contrario, <c>null</c>.</returns>
        public override ICharacter PickUnit(string unitName)
        {
            return unitName.ToLower() switch
            {
                "centuries" => new Centuries(),
                _ => null,
            };
        }
    }
}