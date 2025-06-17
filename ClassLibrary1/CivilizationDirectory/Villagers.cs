
using System;
using System.Collections.Generic;
using ClassLibrary1.CivilizationDirectory;
using CreateBuildings;
namespace ClassLibrary1;

public class Villagers : ICharacter, IBuilder
{
    public int Life { get; set; }
    public int AttackValue { get; set; }
    private Dictionary<string, int> GetCost = new Dictionary<string, int>();
    
    public Villagers(int life, int attackValue)
    {
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
    public void GetCreate(Dictionary<string,int>GetCost)
    {
        GetCost["Madera"] = 10;
        GetCost["Piedra"] = 30;
    }

    public void Build(Buildings target,int builders)
    {
        Console.WriteLine($"El aldeano está construyendo el edificio: {target.Name}");
        target.ConstructionTimeLeft = Math.Max(0, target.ConstructionTimeLeft - builders);
        if (target.ConstructionTimeLeft <= 0)
        {
            Console.WriteLine($"El edificio está construido: {target.Name}");
        }
        else
        {
            Console.WriteLine($"El edificio {target.Name} le faltan {target.ConstructionTimeLeft} segundos");
        }
    }
}
