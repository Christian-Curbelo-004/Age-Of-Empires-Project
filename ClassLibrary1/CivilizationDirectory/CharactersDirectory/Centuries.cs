
using System.Diagnostics;
using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.CivilizationDirectory
{
    public class Centuries : Soldier, IMapEntity
    {
        public Centuries() : base( 100, 40,12, 12)
        {
        }
        public string Symbol { get; set; } = "Ce";
        public override string ToString()
        {
            return $"{Symbol}{OwnerId}"; 
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
