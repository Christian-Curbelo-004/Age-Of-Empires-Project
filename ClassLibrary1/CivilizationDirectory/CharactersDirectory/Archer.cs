

namespace ClassLibrary1.CivilizationDirectory;

public class Archer : Soldier
{
    public Archer() : base(0,20, 10, 10)
    {
    }
    
    public override int Attack(ICharacter target)
    {
        return target.RecieveAttack(AttackValue);
    }

    public override  int RecieveAttack(int damage)
    {
        Life -= damage;
        return Life;
    }
    
}