using System.Collections.Immutable;
using CreateBuildings;

namespace ClassLibrary1;

public class Villagers : ICharacter

{
    public int Life { get; set; }
    public int AttackValue { get; set; }
    
    public Villagers(int life, int attackValue, bool building)
        {
        Life = life;
        AttackValue = attackValue;
        
        }

    public void Attack(ICharacter target)
    {
        Console.WriteLine("El aldeano ataco al enemigo");
        target.RecieveAttack(AttackValue);
    }

    public void RecieveAttack(int damage)
    {
        Life -= damage;
        Console.WriteLine($"El aldeano recibio {damage} de daño");
    }

    public void Build(Buildings building)
    {
        Console.WriteLine($"El aldeano creó {building.Name}");
        Console.WriteLine($"El aldeano tardó {building.ConstructionSpeed}");
        Console.WriteLine($"El aldeano costó {building.Endurence}");
        
    }
}
