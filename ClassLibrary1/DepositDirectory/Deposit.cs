using ClassLibrary1.BuildingsDirectory;

namespace ClassLibrary1.DepositDirectory
{
    /// <summary>
    /// Representa un edificio de tipo depósito que almacena recursos.
    /// Clase abstracta base para depósitos como graneros, minas, etc.
    /// </summary>
    public abstract class Deposit : Buildings
    {
        /// <summary>
        /// Obtiene o establece la capacidad máxima del depósito.
        /// </summary>
        public int MaxCapacity { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad actual almacenada en el depósito.
        /// </summary>
        public int CurrentStorage { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Deposit"/>.
        /// </summary>
        /// <param name="endurence">La durabilidad (vida) del edificio.</param>
        /// <param name="constructiontimeleft">Tiempo de construcción restante en segundos.</param>
        /// <param name="name">El nombre del depósito.</param>
        /// <param name="maxCapacity">La capacidad máxima de almacenamiento.</param>
        public Deposit(int endurence, int constructiontimeleft, string name, int maxCapacity)
            : base(endurence, name)
        {
            MaxCapacity = maxCapacity;
            CurrentStorage = 0;
            ConstructionTime = constructiontimeleft;
        }
    }
}