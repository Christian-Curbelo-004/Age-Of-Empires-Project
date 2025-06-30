
using System.Diagnostics;

namespace ClassLibrary1.CivilizationDirectory
{
    public class Centuries : Soldier
    {
        public Centuries() : base( 100, 40,12, 12)
        {
        }
        public override int Attack(ICharacter target) // Atacar
        {
            return target.RecieveAttack(AttackValue);
        }

        public override int RecieveAttack(int damage) // Recibir ataque
        {
            DeffenseValue -= damage;
            return DeffenseValue;
        }

        public  int Boost(ICharacter target) //Buffeo 
        {
            AttackValue += 10;
            return target.RecieveAttack(AttackValue);
        }
    }
}
