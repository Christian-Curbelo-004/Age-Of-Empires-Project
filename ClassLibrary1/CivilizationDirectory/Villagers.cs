using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.MapDirectory;



namespace ClassLibrary1.UnitsDirectory;

public class Villagers : IMapEntity
{
    public int Life { get; set; }
    public int AttackValue { get; set; }
    public int Speed { get; set; }
    public int OwnerId { get; set; }
    public (int X, int Y) Position { get; set; }
    public bool IsFree { get; set; } = true;
    
    public Villagers(int life, int attackValue, int ownerId, int speed)
    {
        OwnerId= ownerId;
        Life = life;
        AttackValue = attackValue;
        Speed = speed;
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
}