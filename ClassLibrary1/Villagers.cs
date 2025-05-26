namespace ClassLibrary1;

public class Villagers : ICharacter
{
    public int Life { get; set; }
    public int AttackValue { get; set; }
    
    public Villagers(int life, int attackValue)
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
}
