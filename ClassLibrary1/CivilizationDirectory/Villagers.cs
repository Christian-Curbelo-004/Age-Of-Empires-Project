
using System.Collections.Generic;
using CreateBuildings;
namespace ClassLibrary1;

public class Villagers : ICharacter

{
    public int Life { get; set; }
    public int AttackValue { get; set; }
    private Dictionary<string, int> Resources;
    
    public Villagers(int life, int attackValue)
    {
        Life = life;
        AttackValue = attackValue;
        
        Resources = new Dictionary<string, int>  //para poder ver el "inentario" de los recursos que tienen los aldeanos recolectados
        {
            {"Wood", 0} ,{"Stone", 0}, {"Gold",0}
        };
    }

    public int Attack(ICharacter target) //cambie el void que devolvia por un int, ya que nos interesa unicamente el valor, el console.writeline va en el program
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

    public Dictionary<string, int> ObtenerRecursos()
    {
        return Resources;
    }
}
