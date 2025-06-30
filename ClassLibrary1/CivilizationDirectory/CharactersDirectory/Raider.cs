
namespace ClassLibrary1.CivilizationDirectory
{
    public class Raider : Soldier
    {
        public Raider() : base(100, 33,25,15)
        {
        }
        public override int Attack(ICharacter target) //Atacar
        {
            return target.RecieveAttack(AttackValue);
        }

        public override int RecieveAttack(int damage) //Recibir Ataque
        {
            DeffenseValue -= damage;
            return DeffenseValue;
        }

        public int Boost(ICharacter target) // Buffeo
        {
            AttackValue += 10;
            return target.RecieveAttack(AttackValue);
        }
    }
}