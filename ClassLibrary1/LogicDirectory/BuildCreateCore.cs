using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.DepositDirectory;
using ClassLibrary1.UnitsDirectory;

namespace ClassLibrary1.LogicDirectory
{
    /// <summary>
    /// Clase responsable de la creación y construcción de edificios y depósitos en el juego.
    /// </summary>
    public class BuildCreateCore
    {
        private readonly ResourceInventory inventory;
        private readonly UnitAffordable unitAffordable;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="BuildCreateCore"/>.
        /// </summary>
        /// <param name="resourceInventory">Inventario de recursos para poder gastar en construcciones.</param>
        public BuildCreateCore(ResourceInventory resourceInventory)
        {
            this.inventory = resourceInventory;
            this.unitAffordable = new UnitAffordable(resourceInventory);
        }

        /// <summary>
        /// Construye un centro de arqueros si hay recursos suficientes.
        /// </summary>
        /// <param name="archerCenter">Instancia del centro de arqueros a construir.</param>
        public async Task ReturnArcherCenter(ArcherCenter archerCenter)
        {
            if (unitAffordable.CanAfford(CreationCost.ArcherCenter))
            {
                BuildFactory.CreateArcherCenter();
                inventory.Spend(CreationCost.ArcherCenter);
                await ConstructionTimeManager.BuildAsync(archerCenter, 2000);
                archerCenter.IsConstructed = true;
            }
        }

        /// <summary>
        /// Construye un centro cívico si hay recursos suficientes.
        /// </summary>
        /// <param name="civicCenter">Instancia del centro cívico a construir.</param>
        public async Task ReturnCivicCenter(CivicCenter civicCenter)
        {
            if (unitAffordable.CanAfford(CreationCost.CivicCenter))
            {
                BuildFactory.CreateCivicCenter();
                inventory.Spend(CreationCost.CivicCenter);
                await ConstructionTimeManager.BuildAsync(civicCenter, 3000);
                civicCenter.IsConstructed = true;
            }
        }

        /// <summary>
        /// Construye un centro de infantería si hay recursos suficientes.
        /// </summary>
        /// <param name="infanteryCenter">Instancia del centro de infantería a construir.</param>
        public async Task ReturnInfanteryCenter(InfanteryCenter infanteryCenter)
        {
            if (unitAffordable.CanAfford(CreationCost.InfanteryCenter))
            {
                BuildFactory.CreateInfanteryCenter();
                inventory.Spend(CreationCost.InfanteryCenter);
                await ConstructionTimeManager.BuildAsync(infanteryCenter, 2000);
                infanteryCenter.IsConstructed = true;
            }
        }

        /// <summary>
        /// Construye un centro de caballería si hay recursos suficientes.
        /// </summary>
        /// <param name="chivarlyCenter">Instancia del centro de caballería a construir.</param>
        public async Task ReturnChivarlyCenter(ChivarlyCenter chivarlyCenter)
        {
            if (unitAffordable.CanAfford(CreationCost.ChivarlyCenter))
            {
                BuildFactory.CreateChivarlyCenter();
                inventory.Spend(CreationCost.ChivarlyCenter);
                await ConstructionTimeManager.BuildAsync(chivarlyCenter, 2000);
                chivarlyCenter.IsConstructed = true;
            }
        }

        /// <summary>
        /// Construye un centro de saqueadores si hay recursos suficientes.
        /// </summary>
        /// <param name="raiderCenter">Instancia del centro de saqueadores a construir.</param>
        public async Task ReturnRaiderCenter(RaiderCenter raiderCenter)
        {
            if (unitAffordable.CanAfford(CreationCost.RaiderCenter))
            {
                BuildFactory.CreateRaiderCenter();
                inventory.Spend(CreationCost.RaiderCenter);
                await ConstructionTimeManager.BuildAsync(raiderCenter, 2000);
                raiderCenter.IsConstructed = true;
            }
        }

        /// <summary>
        /// Construye un centro de paladines si hay recursos suficientes.
        /// </summary>
        /// <param name="paladinCenter">Instancia del centro de paladines a construir.</param>
        public async Task ReturnPaladinCenter(PaladinCenter paladinCenter)
        {
            if (unitAffordable.CanAfford(CreationCost.PaladinCenter))
            {
                BuildFactory.CreatePaladinCenter();
                inventory.Spend(CreationCost.PaladinCenter);
                await ConstructionTimeManager.BuildAsync(paladinCenter, 2000);
                paladinCenter.IsConstructed = true;
            }
        }

        /// <summary>
        /// Construye un centro de siglos si hay recursos suficientes.
        /// </summary>
        /// <param name="centuriesCenter">Instancia del centro de siglos a construir.</param>
        public async Task ReturnCenturiesCenter(CenturiesCenter centuriesCenter)
        {
            if (unitAffordable.CanAfford(CreationCost.CenturiesCenter))
            {
                BuildFactory.CreateCenturiesCenter();
                inventory.Spend(CreationCost.CenturiesCenter);
                await ConstructionTimeManager.BuildAsync(centuriesCenter, 2000);
                centuriesCenter.IsConstructed = true;
            }
        }

        /// <summary>
        /// Construye un depósito de oro si hay recursos suficientes.
        /// </summary>
        /// <param name="goldDeposit">Instancia del depósito de oro a construir.</param>
        public async Task ReturnGoldDeposit(GoldDeposit goldDeposit)
        {
            if (unitAffordable.CanAfford(CreationCost.GoldDeposit))
            {
                BuildFactory.CreateGoldDeposit(inventory);
                inventory.Spend(CreationCost.GoldDeposit);
                await ConstructionTimeManager.BuildAsync(goldDeposit, 2500);
                goldDeposit.IsConstructed = true;
            }
        }

        /// <summary>
        /// Construye un depósito de madera si hay recursos suficientes.
        /// </summary>
        /// <param name="woodDeposit">Instancia del depósito de madera a construir.</param>
        public async Task ReturnWoodDeposit(WoodDeposit woodDeposit)
        {
            if (unitAffordable.CanAfford(CreationCost.WoodDeposit))
            {
                BuildFactory.CreateWoodDeposit(inventory);
                inventory.Spend(CreationCost.WoodDeposit);
                await ConstructionTimeManager.BuildAsync(woodDeposit, 2500);
                woodDeposit.IsConstructed = true;
            }
        }

        /// <summary>
        /// Construye un depósito de piedra si hay recursos suficientes.
        /// </summary>
        /// <param name="stoneDeposit">Instancia del depósito de piedra a construir.</param>
        public async Task ReturnStoneDeposit(StoneDeposit stoneDeposit)
        {
            if (unitAffordable.CanAfford(CreationCost.StoneDeposit))
            {
                BuildFactory.CreateStoneDeposit(inventory);
                inventory.Spend(CreationCost.StoneDeposit);
                await ConstructionTimeManager.BuildAsync(stoneDeposit, 2500);
                stoneDeposit.IsConstructed = true;
            }
        }

        /// <summary>
        /// Construye un molino de viento si hay recursos suficientes.
        /// </summary>
        /// <param name="windMill">Instancia del molino de viento a construir.</param>
        public async Task ReturnWindmill(WindMill windMill)
        {
            if (unitAffordable.CanAfford(CreationCost.WindMill))
            {
                BuildFactory.CreateWindMill(inventory);
                inventory.Spend(CreationCost.WindMill);
                await ConstructionTimeManager.BuildAsync(windMill, 2500);
                windMill.IsConstructed = true;
            }
        }

        /// <summary>
        /// Construye una casa si hay recursos suficientes.
        /// </summary>
        /// <param name="home">Instancia de la casa a construir.</param>
        public async Task ReturnHome(Home home)
        {
            if (unitAffordable.CanAfford(CreationCost.Home))
            {
                BuildFactory.CreateHome();
                inventory.Spend(CreationCost.Home);
                await ConstructionTimeManager.BuildAsync(home, 1500);
                home.IsConstructed = true;
            }
        }

        /// <summary>
        /// Permite que un aldeano construya un edificio.
        /// </summary>
        /// <param name="villager">Aldeano que realizará la construcción.</param>
        /// <param name="buildings">Edificio a construir.</param>
        /// <returns>True si la construcción fue iniciada correctamente.</returns>
        public bool VillagersBuilding(Villagers villager, Buildings buildings)
        {
            return villager.Build(buildings);
        }
    }
}
