namespace ClassLibrary1;

public class Soldier : ICharacter
{
    public int Life { get; set; }
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    public int ValueCell { get; set; }


    public Soldier(int life, int attackValue, int defenseValue)
    {
        Life = life;
        AttackValue = attackValue;
        DefenseValue = defenseValue;
        ValueCell = 0;
    }

    public int Attack(ICharacter target) // cambio el void que habia, por un int y en vez de consoloe pongo return, ya que es una clase y solo necesitamos retornar el valor
    {
        //Console.WriteLine("El soldado ataco al enemigo");
        int daño = target.RecieveAttack(AttackValue);
        return daño;
    }

    public int RecieveAttack(int damage) // cambio el void que habia, por un int y en vez de console pongo return, ya que es una clase y solo necesitamos retornar el valor
    {
        int damageTaken = damage - DefenseValue;
        if (damageTaken < 0) damageTaken = 0;

        Life -= damageTaken;
        return Life;
        //Console.WriteLine($"El soldado recibió {damageTaken} de daño. Vida restante: {Life}");
    }
}


