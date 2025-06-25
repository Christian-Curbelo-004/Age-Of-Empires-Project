using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.UnitsDirectory;
using CreateBuildings;

namespace ClassLibrary1.LogicDirectory;

public class VillagersLogic : Villagers, ICharacter
{
    public VillagerState State { get; set; } = VillagerState.IsFree;
    public bool IsFree { get; set; } = true;
    public VillagersLogic(int life, int attackValue, int ownerId, int speed)
    : base(life, attackValue, ownerId, speed)
    {
    }

    public enum VillagerState // enum sirve para mostrar el estado del aldeano
    {
        IsFree,
        Construyendo,
    }

    public int Attack(ICharacter target)
    {
        int damageDone = target.RecieveAttack(AttackValue);
        return damageDone;
    }
    
    public int RecieveAttack(int damage)
    {
        Life -= damage;
        return Life;
    }

    public bool Build(Buildings target, int builders)
    {
        if (State == VillagerState.IsFree)
        {
            State = VillagerState.Construyendo;
            return true;
        }
        return false;
    }

    public Cost GetCost()
    {
        return new Cost(120, 50, 0, 0);
    }
}