using ClassLibrary1.CivilizationDirectory.CharactersDirectory;
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

        public virtual int Attack(ICharacter target)  // Metodo para atacar
        {
            int damage = target.RecieveAttack(AttackValue);
            return damage;
        }

        public virtual int RecieveAttack(int damage)  // Metodo para recibir daño 
        {
            Life -= damage;
            return Life;
        }
    }
}