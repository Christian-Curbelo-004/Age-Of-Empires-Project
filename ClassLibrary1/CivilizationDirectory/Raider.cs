
namespace ClassLibrary1.CivilizationDirectory
{
    public class Raider : Soldier, ICharacter
    {
        public Raider() : base(100, 33,25,15)
        {
        }
        public override  int Attack(ICharacter target)
        {
            return target.RecieveAttack(AttackValue);
        }

        public override  int RecieveAttack(int damage)
        {
            DeffenseValue -= damage;
            return DeffenseValue;
        }

        public int BoostAttack(ICharacter target)
        {
            AttackValue += 10;
            return target.RecieveAttack(AttackValue);
        }
    }
}