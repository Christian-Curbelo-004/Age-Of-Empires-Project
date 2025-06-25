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
        Walking
    }

    public string Walking(int x, int y)
    {
        State = VillagerState.Walking;
        
        int newPositionX = x - y;
        int newPositionY = y - x;
        
        int movX = Math.Clamp(newPositionX, -Speed, Speed);  // clamp > para que no se mueva menos de lo permitido ni mas
        int movY = Math.Clamp(newPositionY, -Speed, Speed);

        Position = (Position.X + movX, Position.Y + movY);
        
        if (newPositionX == x && newPositionY == x)
        {
            State = VillagerState.IsFree;
            return $"El aldeano llego a:  {newPositionX}, {newPositionY}";
        }
        return Walking(0,0);
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