using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.CivilizationDirectory.CharactersDirectory;
using ClassLibrary1.MapDirectory;



using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.UnitsDirectory
{
    public class Villagers : IMapEntity, IMovable
    {
        public int Life { get; set; }
        public int AttackValue { get; set; }
        
        // Implementación de IMovable
        public int Speed { get; set; }

        public int OwnerId { get; set; }
        public (int X, int Y) Position { get; set; }
        public bool IsFree { get; set; } = true;

        public Villagers(int life, int attackValue, int ownerId, int speed)
        {
            OwnerId= ownerId;
            Life = life;
            AttackValue = attackValue;
            Speed = speed;
        }

        public int Attack(ICharacter target)
        {
            int DamageDone = target.RecieveAttack(AttackValue);
            return DamageDone;
        }

        public int RecieveAttack(int damage)
        {
            Life -= damage;
            return Life;
        }
    }
}