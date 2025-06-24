

namespace ClassLibrary1.CivilizationDirectory;

public class Infantery : Soldier                                               
{
    public Infantery() : base(100,14,10,13)
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
