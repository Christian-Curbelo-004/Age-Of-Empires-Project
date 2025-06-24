
namespace ClassLibrary1.CivilizationDirectory;


public class Paladin : Soldier                                         //ICharacter 
{
    public Paladin() : base(100, 25,  40,9) 
    {
    }
    public override int Attack(ICharacter target)
    {
        return target.RecieveAttack(AttackValue);
    }

    public override  int RecieveAttack(int damage)
    {
        DeffenseValue -= damage;
        return DeffenseValue;
    }

    public  int Boost(int damage)
    {
        DeffenseValue += 15;
        return Boost(damage);
    }

}