using ClassLibrary1.UnitsDirectory;
namespace ClassLibrary1.CivilizationDirectory;

public class Archer : Soldier //Hereda de Soldier
{
    public Archer() : base(100,20, 10, 10)
    {
    }
    
    public override int Attack(ICharacter target)  // Metodo atacar
    {
        return target.RecieveAttack(AttackValue);
    }

    public override  int RecieveAttack(int damage) // Metodo recibir ataque
    {
        Life -= damage;
        return Life;
    }
}