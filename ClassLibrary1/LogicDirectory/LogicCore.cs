using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.FacadeDirectory;
using GameModels;
namespace ClassLibrary1.LogicDirectory;

public abstract class LogicCore : ILogic
{
    public void CentersLogic(Player playerOne)
    {   
        void CreateSoldier(Soldier soldier)
        {
            var cost = soldier.GetCreationCost();
            if (playerOne.HasResources(cost) && playerOne.CivicCenter.CanCreateSoldiers())
            {
                playerOne.SpendResources(cost);
                var newSoldier = playerOne.CivicCenter.CreateSoldier(soldier);
                playerOne.AddSoldier(newSoldier);
            }
        }
        CreateSoldier(UnitFactory.CreateInfantery());
        CreateSoldier(UnitFactory.CreateArcher());
        CreateSoldier(UnitFactory.CreateChivarly());

        void CreateVillagers(Villagers villager)
        {
            if (playerOne.CivicCenter.CanCreateVillagers())
            {
                var newVillager = playerOne.CivicCenter.CreateVillagers();
                if (newVillager != null)
                {
                    var cost = villager.GetCreationCost();
                    if (playerOne.HasResources(cost))
                    {
                        playerOne.SpendResources(cost);
                        playerOne.AddVillagers(newVillager);
                    }
                }
            }
        }
        CreateVillagers(new Villagers(100,5, 1));
    }
    public void DepositLogic(Player playerOne)
    {
        int collectors = 1;
        foreach (var villager in playerOne.Villagers)
        {
            if (!villager.IsFree) continue;
            var task = villager.CurrentTask;
            if (task == null || task.ResourceType == null) continue;

            var deposit = playerOne.GetAvailableDeposit(task.ResourceType);
            if (deposit == null)
            {
                continue;
            }

            int delivered = deposit.StoreResource(task.ExtractResources(collectors), task.ResourceType);
            villager.IsFree = true;

        }
    }
    public void VillagersLogic(Player playerOne, int collectors)
    {   
        void TransformVillager(Soldier soldier)
        {
            var villager = playerOne.GetFirstVillagerFree();
            if (villager == null) return;
            
            var cost = soldier.GetCreationCost();
            if (playerOne.CivicCenter.CanCreateSoldiers())
            {
                if (playerOne.HasResources(cost))
                {
                    playerOne.SpendResources(cost);
                    playerOne.Villagers.Remove(villager);

                    var newSoldier = playerOne.CivicCenter.CreateSoldier(soldier);
                    if (newSoldier != null)
                    {
                        playerOne.AddSoldier(newSoldier);
                    }
                }
            }
        }
        TransformVillager( UnitFactory.CreateArcher());
        TransformVillager(UnitFactory.CreateChivarly());
        TransformVillager(UnitFactory.CreateInfantery());
        {
            List<Villagers> freeVillagers = new List<Villagers>();
            foreach (var villager in playerOne.Villagers)
            {
                if (villager.IsFree)
                {
                    freeVillagers.Add(villager);
                    if (freeVillagers.Count == collectors)
                        break;
                }
            }

            if (freeVillagers.Count == 0) return;

            foreach (var villager in freeVillagers) 
            {
                var quarry = playerOne.Quaries.FirstOrDefault(q => q.RemainingResource > 0);
                if (quarry == null) continue;

                GameResourceType resourceType;
                switch (quarry.CollectionType.ToLower())
                {
                    case "madera": resourceType = GameResourceType.Wood; break;
                    case "gold": resourceType = GameResourceType.Gold; break;
                    case "stone": resourceType = GameResourceType.Stone; break;
                    case "food": resourceType = GameResourceType.Food; break;
                    default: continue;
                }

                int collected = quarry.GetResources(1); // podés cambiar esto a usar 1 o el total de freeVillagers.Count
                if (collected <= 0) continue;

                var deposit = playerOne.GetAvailableDeposit(resourceType);
                if (deposit == null) continue;

                int stored = deposit.StoreResource(collected, resourceType);
                playerOne.Resources[resourceType] += stored;
                villager.IsFree = quarry.RemainingResource > 0;
            }
        }
    }
}