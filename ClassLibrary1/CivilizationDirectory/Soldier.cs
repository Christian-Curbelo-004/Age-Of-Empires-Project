using ClassLibrary1.CivilizationDirectory.CharactersDirectory;
using ClassLibrary1.LogicDirectory;
namespace ClassLibrary1.CivilizationDirectory
{
    public abstract class Soldier : ICharacter, IMovable
    {
        public virtual int Life { get; set; }
        public virtual int AttackValue { get; set; }
        public virtual int DeffenseValue { get; set; }
        public virtual int Speed { get; set; }  // Propiedad requerida por IMovable

        public Soldier(int life, int attackValue, int defenseValue, int speed)
        {
            Life = life;
            AttackValue = attackValue;
            DeffenseValue = defenseValue;
            Speed = speed;
        }

        public virtual int Attack(ICharacter target)
        {
            int daño = target.RecieveAttack(AttackValue);
            return daño;
        }

        public virtual int RecieveAttack(int damage)
        {
            Life -= damage;
            return Life;
        }

        public Cost GetCost()
        {
            return new Cost(100, 50, 0, 0);
        }
    }
}


