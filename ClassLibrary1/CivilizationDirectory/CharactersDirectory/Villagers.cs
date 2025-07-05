using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.CivilizationDirectory.CharactersDirectory;
using CreateBuildings;


namespace ClassLibrary1.UnitsDirectory
{
    public class Villagers : Units, IMovable, ICharacter 
    {
        public int Life { get; set; }
        public int AttackValue { get; set; }

        // Implementación de IMovable
        public new int Speed { get; set; }
        public new string Name { get; set; }
        public new int OwnerId { get; set; }
        public new (int X, int Y) Position { get; set; }
        public VillagerState State { get; set; } = VillagerState.IsFree;
        
        public enum VillagerState // enum sirve para mostrar el estado del aldeano
        {
            IsFree,
            Construyendo,
        }
        

        
        public Villagers(int life, int attackValue, int ownerId, int speed)
        {
            OwnerId = ownerId;
            Life = life;
            AttackValue = attackValue;
            Speed = speed;
            
        }
        public int Attack(ICharacter target)
        {
            int damageDone = target.RecieveAttack(AttackValue);
            return damageDone;
        }
        public int RecieveAttack(int damage)
        {
            Life -= damage;
            return Life;
        }
        public bool Build(Buildings buildings) // llamado desde BuildCreateCore
        {
            if (State == VillagerState.IsFree)
            {
                State = VillagerState.Construyendo;
                return true;
            }
            return false;
        }
    }
}