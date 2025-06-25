
using System.Diagnostics;

namespace ClassLibrary1.CivilizationDirectory
{
    public class Centuries : Soldier
    {
        public Centuries() : base( 10, 40,12, 12)
        {
        }
        public override int Attack(ICharacter target)
        {
            return target.RecieveAttack(AttackValue);
        }

        public override int RecieveAttack(int damage)
        {
            DeffenseValue -= damage;
            return DeffenseValue;
        }

        public  int Boost(ICharacter target)
        {
            AttackValue += 10;
            return target.RecieveAttack(AttackValue);
        }
    }
}
