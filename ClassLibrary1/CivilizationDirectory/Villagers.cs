using System.Collections.Immutable;
using CreateBuildings;

namespace ClassLibrary1;

public class Villagers : ICharacter

{
    public int Life { get; set; }
    public int AttackValue { get; set; }
    public int ValueCell { get; set; }
    public Dictionary<string, int> Resources { get; set;}
    
    public Villagers(int life, int attackValue, bool building)
        {
        Life = life;
        AttackValue = attackValue;
        ValueCell = 0;

        Resources = new Dictionary<string, int>
        {
            { "Stone", 0 }, { "Gold", 0 }, { "Wood", 0 }
        };
        }

    public int Attack(ICharacter target)  //cambie el void que devolvia por un int, ya que nos interesa unicamente el valor, el console.writeline va en el program
    {
        //Console.WriteLine("El aldeano ataco al enemigo");
        int daño_recibido = target.RecieveAttack(AttackValue);

        return daño_recibido;
    }

    public int RecieveAttack(int damage)
    {
        Life -= damage;
        return Life;
        //Console.WriteLine($"El aldeano recibio {damage} de daño");
    }

    public Dictionary<string, int> ShowResources()
    {
        return Resources;
    }
}
