using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.CivilizationDirectory.CharactersDirectory;
using ClassLibrary1.QuaryDirectory; 

namespace ClassLibrary1.UnitsDirectory
{
    public class Villagers : GameUnit, IMovable, ICharacter, IResourceCollector
    {
        public int Life { get; set; }
        public int AttackValue { get; set; }
        public new int Speed { get; set; }
        public new string Name { get; set; }
        public new int OwnerId { get; set; }
        public new (int X, int Y) Position { get; set; }
        public VillagerState State { get; set; } = VillagerState.IsFree;

        public enum VillagerState 
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

        public bool Build(Buildings buildings)
        {
            if (State == VillagerState.IsFree)
            {
                State = VillagerState.Construyendo;
                return true;
            }
            return false;
        }

        public int CalculateCollected(int available, int extractionRate, int collectors)
        {
            int totalCollected = extractionRate * collectors;
            if (totalCollected > available)
                return available;
            return totalCollected;
        }
    }
}