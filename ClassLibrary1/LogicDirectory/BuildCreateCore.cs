using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.DepositDirectory;
namespace ClassLibrary1.LogicDirectory
{
    /// <summary>
    /// Clase responsable de la creación y construcción de edificios y depósitos en el juego.
    /// </summary>
    public class BuildCreateCore
    {
        private readonly ResourceInventory _inventory;
        private readonly UnitAffordable unitAffordable;
        public BuildCreateCore(ResourceInventory resourceInventory)
        {
            _inventory = resourceInventory;
            this.unitAffordable = new UnitAffordable(resourceInventory);
        }
        public async Task<ArcherCenter?> BuildArcherCenterAtAsync(int x, int y, int playerId)
        {
            if (!unitAffordable.CanAfford(CreationCost.ArcherCenter))
                return null;

            var archerCenter = BuildFactory.CreateArcherCenter(); // este método ahora debe devolver el objeto
            archerCenter.Position = (x, y);
            archerCenter.OwnerId = playerId;

            _inventory.Spend(CreationCost.ArcherCenter);
            await ConstructionTimeManager.BuildAsync(archerCenter, 2000);
            archerCenter.IsConstructed = true;

            return archerCenter;
        }
        public async Task<InfanteryCenter?> BuildInfanteryCenterAtAsync(int x, int y, int playerId)
        {
            if (!unitAffordable.CanAfford(CreationCost.InfanteryCenter))
                return null;

            var infanteryCenter = BuildFactory.CreateInfanteryCenter(); // este método ahora debe devolver el objeto
            infanteryCenter.Position = (x, y);
            infanteryCenter.OwnerId = playerId;

            _inventory.Spend(CreationCost.InfanteryCenter);
            await ConstructionTimeManager.BuildAsync(infanteryCenter, 2000);
            infanteryCenter.IsConstructed = true;

            return infanteryCenter;
        }
        public async Task<RaiderCenter?> BuildRaiderCenterAtAsync(int x, int y, int playerId)
        {
            if (!unitAffordable.CanAfford(CreationCost.RaiderCenter))
                return null;

            var raiderCenter = BuildFactory.CreateRaiderCenter(); // este método ahora debe devolver el objeto
            raiderCenter.Position = (x, y);
            raiderCenter.OwnerId = playerId;

            _inventory.Spend(CreationCost.RaiderCenter);
            await ConstructionTimeManager.BuildAsync(raiderCenter, 2000);
            raiderCenter.IsConstructed = true;

            return raiderCenter;
        }
        public async Task<ChivarlyCenter?> BuildChivarlyCenterAtAsync(int x, int y, int playerId)
        {
            if (!unitAffordable.CanAfford(CreationCost.ChivarlyCenter))
                return null;

            var chivarlyCenter = BuildFactory.CreateChivarlyCenter(); // este método ahora debe devolver el objeto
            chivarlyCenter.Position = (x, y);
            chivarlyCenter.OwnerId = playerId;

            _inventory.Spend(CreationCost.ChivarlyCenter);
            await ConstructionTimeManager.BuildAsync(chivarlyCenter, 2000);
            chivarlyCenter.IsConstructed = true;

            return chivarlyCenter;
        }
        public async Task<StoneDeposit?> BuildStoneDepositAtAsync(int x, int y, int playerId)
        {
            if (!unitAffordable.CanAfford(CreationCost.StoneDeposit))
                return null;

            var stoneDeposit = BuildFactory.CreateStoneDeposit(_inventory); // este método ahora debe devolver el objeto
            stoneDeposit.Position = (x, y);
            stoneDeposit.OwnerId = playerId;

            _inventory.Spend(CreationCost.StoneDeposit);
            await ConstructionTimeManager.BuildAsync(stoneDeposit, 2000);
            stoneDeposit.IsConstructed = true;

            return stoneDeposit;
        }
        public async Task<GoldDeposit?> BuildGoldDepositAtAsync(int x, int y, int playerId)
        {
            if (!unitAffordable.CanAfford(CreationCost.GoldDeposit))
                return null;

            var goldDeposit = BuildFactory.CreateGoldDeposit(_inventory); // este método ahora debe devolver el objeto
            goldDeposit.Position = (x, y);
            goldDeposit.OwnerId = playerId;

            _inventory.Spend(CreationCost.GoldDeposit);
            await ConstructionTimeManager.BuildAsync(goldDeposit, 2000);
            goldDeposit.IsConstructed = true;

            return goldDeposit;
        }
        public async Task<WoodDeposit?> BuildWoodDepositAtAsync(int x, int y, int playerId)
        {
            if (!unitAffordable.CanAfford(CreationCost.WoodDeposit))
                return null;

            var woodDeposit = BuildFactory.CreateWoodDeposit(_inventory); // este método ahora debe devolver el objeto
            woodDeposit.Position = (x, y);
            woodDeposit.OwnerId = playerId;

            _inventory.Spend(CreationCost.WoodDeposit);
            await ConstructionTimeManager.BuildAsync(woodDeposit, 2000);
            woodDeposit.IsConstructed = true;

            return woodDeposit;
        }
        public async Task<CivicCenter?> BuildCivicCenterAtAsync(int x, int y, int playerId)
        {
            if (!unitAffordable.CanAfford(CreationCost.CivicCenter))
                return null;

            var civicCenter = BuildFactory.CreateCivicCenter(); // este método ahora debe devolver el objeto
            civicCenter.Position = (x, y);
            civicCenter.OwnerId = playerId;

            _inventory.Spend(CreationCost.CivicCenter);
            await ConstructionTimeManager.BuildAsync(civicCenter, 2000);
            civicCenter.IsConstructed = true;

            return civicCenter;
        }
        public async Task<Home?> BuildHomeAtAsync(int x, int y, int playerId)
        {
            if (!unitAffordable.CanAfford(CreationCost.Home))
                return null;

            var home = BuildFactory.CreateHome(); // este método ahora debe devolver el objeto
            home.Position = (x, y);
            home.OwnerId = playerId;

            _inventory.Spend(CreationCost.CivicCenter);
            await ConstructionTimeManager.BuildAsync(home, 2000);
            home.IsConstructed = true;

            return home;
        }
        public async Task<PaladinCenter?> BuildPaladinCenterAtAsync(int x, int y, int playerId)
        {
            if (!unitAffordable.CanAfford(CreationCost.PaladinCenter))
                return null;

            var paladinCenter = BuildFactory.CreatePaladinCenter(); // este método ahora debe devolver el objeto
            paladinCenter.Position = (x, y);
            paladinCenter.OwnerId = playerId;

            _inventory.Spend(CreationCost.WindMill);
            await ConstructionTimeManager.BuildAsync(paladinCenter, 2000);
            paladinCenter.IsConstructed = true;

            return paladinCenter;
        }
        public async Task<WindMill?> BuildWindMillAtAsync(int x, int y, int playerId)
        {
            if (!unitAffordable.CanAfford(CreationCost.WindMill))
                return null;

            var windMill = BuildFactory.CreateWindMill(_inventory); // este método ahora debe devolver el objeto
            windMill.Position = (x, y);
            windMill.OwnerId = playerId;

            _inventory.Spend(CreationCost.CivicCenter);
            await ConstructionTimeManager.BuildAsync(windMill, 2000);
            windMill.IsConstructed = true;

            return windMill;
        }
        public async Task<CenturiesCenter?> BuildCenturiesCenterAtAsync(int x, int y, int playerId)
        {
            if (!unitAffordable.CanAfford(CreationCost.CenturiesCenter))
                return null;

            var centuriesCenter = BuildFactory.CreateCenturiesCenter(); // este método ahora debe devolver el objeto
            centuriesCenter.Position = (x, y);
            centuriesCenter.OwnerId = playerId;

            _inventory.Spend(CreationCost.CenturiesCenter);
            await ConstructionTimeManager.BuildAsync(centuriesCenter, 2000);
            centuriesCenter.IsConstructed = true;

            return centuriesCenter;
        }
    }
}
