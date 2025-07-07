using ClassLibrary1.UnitsDirectory;

namespace ClassLibrary1.CivilizationDirectory
{
    /// <summary>
    /// Clase abstracta que representa una civilización con sus unidades.
    /// </summary>
    public abstract class Civilization
    {
        /// <summary>
        /// Lista de aldeanos pertenecientes a la civilización.
        /// </summary>
        public List<Villagers> Villagers { get; set; }
        
        public Player Player { get; set; }

        /// <summary>
        /// Lista de soldados pertenecientes a la civilización.
        /// </summary>
        public List<Soldier> Soldiers { get; set; }

        /// <summary>
        /// Lista de todas las unidades (personajes) de la civilización.
        /// </summary>
        public List<ICharacter> Units { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Civilization"/>.
        /// </summary>
        protected Civilization()
        {
            Villagers = new List<Villagers>();
            Soldiers = new List<Soldier>();
            Units = new List<ICharacter>();
        }

        /// <summary>
        /// Selecciona una unidad basada en el nombre proporcionado.
        /// </summary>
        /// <param name="unitName">Nombre de la unidad a seleccionar.</param>
        /// <returns>La unidad que corresponde al nombre dado.</returns>
        public abstract ICharacter PickUnit(string unitName);
        
        public string PickYourCivilization(string option)
        { 
            switch (option)
            { 
                case "1":
                    return "Roman";
                case "2":
                    return "Vikings";
                case "3":
                    return "Templaries";
                default:
                    return "No se encontró la civilizacion";
                }
            }
            
        }
    }