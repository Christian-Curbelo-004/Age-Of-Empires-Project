using ClassLibrary1.LogicDirectory;

namespace ClassLibrary1.DepositDirectory
{
    /// <summary>
    /// Representa un molino de viento que funciona como depósito de comida para el jugador.
    /// Hereda de la clase <see cref="Deposit"/>.
    /// </summary>
    public class WindMill : Deposit
    {
        /// <summary>
        /// Obtiene o establece el identificador del jugador propietario del molino.
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Obtiene la cantidad actual de comida almacenada en el molino.
        /// </summary>
        public int CurrentFood { get; private set; }

        /// <summary>
        /// Inventario de recursos del jugador asociado a este depósito.
        /// </summary>
        private readonly ResourceInventory _inventory;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="WindMill"/>.
        /// </summary>
        /// <param name="endurance">La resistencia del edificio.</param>
        /// <param name="constructionTimeLeft">El tiempo restante para completar la construcción.</param>
        /// <param name="name">El nombre del edificio.</param>
        /// <param name="maxCapacity">La capacidad máxima de almacenamiento de comida.</param>
        /// <param name="ownerId">El ID del jugador propietario del edificio.</param>
        /// <param name="inventory">El inventario de recursos del jugador.</param>
        public WindMill(int endurance, int constructionTimeLeft, string name, int maxCapacity, int ownerId,
            ResourceInventory inventory)
            : base(endurance, constructionTimeLeft, name, maxCapacity)
        {
            OwnerId = ownerId;
            CurrentFood = 100;
            _inventory = inventory;
        }

        /// <summary>
        /// Almacena comida en el molino hasta alcanzar la capacidad máxima y actualiza el inventario del jugador.
        /// </summary>
        /// <param name="amount">La cantidad de comida a almacenar.</param>
        public void StoreFood(int amount)
        {
            int deposited = Math.Min(amount, MaxCapacity - CurrentFood);
        }
    }
}