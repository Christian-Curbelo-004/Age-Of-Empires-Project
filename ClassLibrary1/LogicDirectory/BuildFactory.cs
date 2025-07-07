using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.DepositDirectory;

namespace ClassLibrary1.LogicDirectory
{
    /// <summary>
    /// Fábrica estática para crear instancias de edificios y depósitos con valores predeterminados.
    /// </summary>
    public class BuildFactory
    {
        private readonly IResourceInventory inventory;

        /// <summary>
        /// Crea un nuevo <see cref="ChivarlyCenter"/> con valores predeterminados.
        /// </summary>
        /// <returns>Instancia de <see cref="ChivarlyCenter"/>.</returns>
        public static ChivarlyCenter CreateChivarlyCenter()
        {
            return new ChivarlyCenter(100, 0, "Chivarly Center", 0);
        }

        /// <summary>
        /// Crea un nuevo <see cref="CivicCenter"/> con valores predeterminados.
        /// </summary>
        /// <returns>Instancia de <see cref="CivicCenter"/>.</returns>
        public static CivicCenter CreateCivicCenter()
        {
            return new CivicCenter(10, 20, "CivicCenter", 1)
            {
                ActualHealth = 500,
                ConstructionTime = 0,
                Endurence = 500,
                Name = "CivicCenter",
                OwnerId = 0,
            };
        }

        /// <summary>
        /// Crea un nuevo <see cref="InfanteryCenter"/> con valores predeterminados.
        /// </summary>
        /// <returns>Instancia de <see cref="InfanteryCenter"/>.</returns>
        public static InfanteryCenter CreateInfanteryCenter()
        {
            return new InfanteryCenter(100, 0, "Infantery Center", 0);
        }

        /// <summary>
        /// Crea un nuevo <see cref="ArcherCenter"/> con valores predeterminados.
        /// </summary>
        /// <returns>Instancia de <see cref="ArcherCenter"/>.</returns>
        public static ArcherCenter CreateArcherCenter()
        {
            return new ArcherCenter(100, 0, "Archer Center", 0);
        }

        /// <summary>
        /// Crea un nuevo <see cref="PaladinCenter"/> con valores predeterminados.
        /// </summary>
        /// <returns>Instancia de <see cref="PaladinCenter"/>.</returns>
        public static PaladinCenter CreatePaladinCenter()
        {
            return new PaladinCenter(150, 0, "Paladin Center", 0);
        }

        /// <summary>
        /// Crea un nuevo <see cref="RaiderCenter"/> con valores predeterminados.
        /// </summary>
        /// <returns>Instancia de <see cref="RaiderCenter"/>.</returns>
        public static RaiderCenter CreateRaiderCenter()
        {
            return new RaiderCenter(150, 0, "Raider Center", 0);
        }

        /// <summary>
        /// Crea un nuevo <see cref="CenturiesCenter"/> con valores predeterminados.
        /// </summary>
        /// <returns>Instancia de <see cref="CenturiesCenter"/>.</returns>
        public static CenturiesCenter CreateCenturiesCenter()
        {
            return new CenturiesCenter(150, 0, "Centuries Center", 0);
        }

        /// <summary>
        /// Crea un nuevo <see cref="Home"/> con valores predeterminados.
        /// </summary>
        /// <returns>Instancia de <see cref="Home"/>.</returns>
        public static Home CreateHome()
        {
            return new Home(80, 0, "Home");
        }

        /// <summary>
        /// Crea un nuevo depósito de oro con valores predeterminados.
        /// </summary>
        /// <param name="inventory">Inventario de recursos asociado al depósito.</param>
        /// <returns>Instancia de <see cref="GoldDeposit"/>.</returns>
        public static GoldDeposit CreateGoldDeposit(ResourceInventory inventory)
        {
            return new GoldDeposit(200, 0, "Gold Deposit", 100, 0, inventory);
        }

        /// <summary>
        /// Crea un nuevo depósito de piedra con valores predeterminados.
        /// </summary>
        /// <param name="inventory">Inventario de recursos asociado al depósito.</param>
        /// <returns>Instancia de <see cref="StoneDeposit"/>.</returns>
        public static StoneDeposit CreateStoneDeposit(ResourceInventory inventory)
        {
            return new StoneDeposit(200, 0, "Stone Deposit", 100, 0, inventory);
        }

        /// <summary>
        /// Crea un nuevo depósito de madera con valores predeterminados.
        /// </summary>
        /// <param name="inventory">Inventario de recursos asociado al depósito.</param>
        /// <returns>Instancia de <see cref="WoodDeposit"/>.</returns>
        public static WoodDeposit CreateWoodDeposit(ResourceInventory inventory)
        {
            return new WoodDeposit(200, 0, "Wood Deposit", 100, 0, inventory);
        }

        /// <summary>
        /// Crea un nuevo molino de viento con valores predeterminados.
        /// </summary>
        /// <param name="inventory">Inventario de recursos asociado al molino.</param>
        /// <returns>Instancia de <see cref="WindMill"/>.</returns>
        public static WindMill CreateWindMill(ResourceInventory inventory)
        {
            return new WindMill(200, 0, "WindMill", 100, 0, inventory);
        }
    }
}
