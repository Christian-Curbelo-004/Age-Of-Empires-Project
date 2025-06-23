using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.DepositDirectory;
using ClassLibrary1.FacadeDirectory;
using ClassLibrary1.LogicDirectory;
using CreateBuildings;
using GameResourceType = GameModels.GameResourceType;
namespace ClassLibrary1;

public class Villagers : ICharacter, IBuilder, ICollect, IMapEntidad
{
    public int Life { get; set; }
    public int AttackValue { get; set; }
    public int Speed { get; set; }
    public IWorkTarget CurrentTask { get; set; }
    public int OwnerId { get; set; }
    public string Name { get; set; }
    public string EntityType => "Villagers";
    public bool IsFree { get; set; } = true;
    public Dictionary<GameResourceType, int> ConstructionCost { get;  set; } = new ();
    
    public Villagers(int life, int attackValue, int ownerId)
    {
        OwnerId= ownerId;
        Life = life;
        AttackValue = attackValue;
    }
    public int Attack(ICharacter target) //cambie el void que devolvia por un int, ya que nos interesa unicamente el valor, el console.writeline va en el program
    {
        //Console.WriteLine("El aldeano ataco al enemigo");
        int DamageDone = target.RecieveAttack(AttackValue);

        return DamageDone;
    }

    public int RecieveAttack(int damage)
    {
        Life -= damage;
        return Life;
        //Console.WriteLine($"El aldeano recibio {damage} de daño");
    }
    public Dictionary<GameResourceType, int> GetCreationCost()
    {
        return new Dictionary<GameResourceType, int>
        {
            {GameResourceType.Stone,100},
            {GameResourceType.Gold, 40},
            {GameResourceType.Food, 150}
        };
    }
    public bool Build(Buildings target,int builders)
    {
        target.ConstructionTimeLeft = Math.Max(0, target.ConstructionTimeLeft - builders);
        if (target.ConstructionTimeLeft <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Collect(Quary target, int collectors)
    {
        target.ExtractionRate = Math.Max(0, target.ExtractionRate - collectors);
        if (target.ExtractionRate <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void VillagersLogic(Player player, int collectors)
    {
        List<Villagers> freeVillagers = new List<Villagers>();
        foreach (var villager in player.Villagers)
        {
            if (villager.IsFree)
            {
                freeVillagers.Add(villager);
                if (freeVillagers.Count == collectors)
                    break;
            }
        }
        if (freeVillagers.Count == 0) return; 
        foreach (var villager in player.Villagers)
        {
            if (!villager.IsFree) continue;
            
            var quarry = player.Quaries.FirstOrDefault(q => q.RemainingResource > 0);
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
            int collected = quarry.GetResources(1);
            if (collected <= 0) continue;
            
            var deposit = player.GetAvailableDeposit(resourceType);
            if (deposit == null) continue;

            int stored = deposit.StoreResource(collected, resourceType);
            player.Resources[resourceType] += stored;
            villager.IsFree = quarry.RemainingResource > 0;
        }
    }
}
