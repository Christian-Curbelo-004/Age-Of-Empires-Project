using GameResourceType = GameModels.GameResourceType;
namespace ClassLibrary1.CivilizationDirectory;

public class Soldier : ICharacter
{
    public virtual int Life { get; set; }
    public virtual int AttackValue { get; set; }
    public virtual int DeffenseValue { get; set; }
    public virtual int Speed { get; set; }
    public Dictionary<GameResourceType, int>ConstructionCost { get;  set; } = new ();
    public Soldier(int life, int attackValue, int defenseValue, int speed)
    {
        Life = life;
        AttackValue = attackValue;
        DeffenseValue = defenseValue;
        Speed = speed;

    }
    public virtual int Attack(ICharacter target) // cambio el void que habia, por un int y en vez de consoloe pongo return, ya que es una clase y solo necesitamos retornar el valor
    {
        //Console.WriteLine("El soldado ataco al enemigo");
        int daño = target.RecieveAttack(AttackValue);
        return daño;
    }
    
    public virtual int RecieveAttack(int damage) // cambio el void que habia, por un int y en vez de console pongo return, ya que es una clase y solo necesitamos retornar el valor
    {
        int damageTaken = damage - DeffenseValue;
        if (damageTaken < 0) damageTaken = 0;

        Life -= damageTaken;
        return Life;
        //Console.WriteLine($"El soldado recibió {damageTaken} de daño. Vida restante: {Life}");
    }
    public Dictionary<GameResourceType, int> GetCreate()
    {
        return ConstructionCost;
    }
}


