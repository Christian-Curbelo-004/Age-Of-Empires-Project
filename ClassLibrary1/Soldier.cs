namespace ClassLibrary1;

public class Soldier : ICharacter
{
    public int Life { get; set; }
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }


    public Soldier(int life, int attackValue, int defenseValue)
    {
        Life = life;
        AttackValue = attackValue;
        DefenseValue = defenseValue;
    }

    public void Attack(ICharacter target)
    {
        Console.WriteLine("El soldado ataco al enemigo");
        target.RecieveAttack(AttackValue);
    }

    public void RecieveAttack(int damage) // caso de ejemplo para probar 
    {
        int damageTaken = damage - DefenseValue;
        if (damageTaken < 0) damageTaken = 0;

        Life -= damageTaken;
        Console.WriteLine($"El soldado recibió {damageTaken} de daño. Vida restante: {Life}");
    }
}


