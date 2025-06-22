using ClassLibrary1.CivilizationDirectory;
namespace ClassLibrary1.LogicDirectory;

public abstract class LogicCore : ILogic
{
    public void CentersLogic(PlayerOne player)
    {   
        void CreateSoldier(Soldier soldier)
        {
            var cost = soldier.GetCreationCost();
            if (player.HasResources(cost) && player.CivicCenter.CanCreateSoldiers())
            {
                player.SpendResources(cost);
                var newSoldier = player.CivicCenter.CreateSoldier(soldier);
                player.AddSoldier(newSoldier);
            }
        }
        CreateSoldier(UnitFactory.CreateInfantery());
        CreateSoldier(UnitFactory.CreateArcher());
        CreateSoldier(UnitFactory.CreateChivarly());

        void CreateVillagers(Villagers villager)
        {
            if (player.CivicCenter.CanCreateVillagers())
            {
                var newVillager = player.CivicCenter.CreateVillagers();
                if (newVillager != null)
                {
                    var cost = villager.GetCreationCost();
                    if (player.HasResources(cost))
                    {
                        player.SpendResources(cost);
                        player.AddVillagers(newVillager);
                    }
                }
            }
        }
        CreateVillagers(new Villagers(100,5));
    }
    public void DepositLogic()
    {
        
    }
    public void VillagersLogic(PlayerOne player)
    {   
        void TransformVillager(Soldier soldier)
        {
            var villager = player.GetFirstVillagerFree();
            if (villager == null) return;
            
            var cost = soldier.GetCreationCost();
            if (player.CivicCenter.CanCreateSoldiers())
            {
                if (player.HasResources(cost))
                {
                    player.SpendResources(cost);
                    player.Villagers.Remove(villager);

                    var newSoldier = player.CivicCenter.CreateSoldier(soldier);
                    if (newSoldier != null)
                    {
                        player.AddSoldier(newSoldier);
                    }
                }
            }
        }
        TransformVillager( UnitFactory.CreateArcher());
        TransformVillager(UnitFactory.CreateChivarly());
        TransformVillager(UnitFactory.CreateInfantery());
    }
}