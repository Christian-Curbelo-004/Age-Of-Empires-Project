
using ClassLibrary1.CivilizationDirectory;

namespace TestProject1
{
    public class TestSoldier
    {
        
        private class TesterSoldier : Soldier
        {
            public TesterSoldier(int life, int attackValue, int defenseValue, int speed)
                : base(life, attackValue, defenseValue, speed)
            {
            }
        }

        [Test]
        public void Attack_ShouldReduceTargetLife()
        {
            var attacker = new TesterSoldier(100, 20, 5, 10);
            var target = new TesterSoldier(100, 15, 5, 8);

            int damage = attacker.Attack(target);

            Assert.That(target.Life, Is.EqualTo(80));
            Assert.That(damage, Is.EqualTo(80));
        }

        [Test]
        public void RecieveAttack_ShouldReduceLifeByDamage()
        {
            var soldier = new TesterSoldier(100, 10, 5, 5);

            int remainingLife = soldier.RecieveAttack(70);

            Assert.That(remainingLife, Is.EqualTo(30));
        }
    }
}