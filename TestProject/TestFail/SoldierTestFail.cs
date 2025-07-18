using ClassLibrary1.CivilizationDirectory;


namespace TestProject.TestFail
{
    public class TestSoldierFail
    {

        private class TesterSoldierFail : Soldier
        {
            public TesterSoldierFail(int life, int attackValue, int defenseValue, int speed)
                : base(life, attackValue, defenseValue, speed)
            {

            }
        }

        private Soldier _soldier;
        
        //Arrange
        [SetUp]
        public void Setup()
        {
            _soldier = new TesterSoldierFail(100, 80, 54, 23);
        }

        //Assert
        [Test]
        public void TestVerificacionDeLaVidaDelSoldado()
        {
            Assert.That(_soldier.Life, Is.EqualTo(100));
        }

        
        // Act
        [Test] 
        public void TestDePerdidaDeVidaDelSoldado()
        {
            _soldier.RecieveAttack(30);
            Assert.That(_soldier.Life, Is.EqualTo(20));
        }

        [Test]
        public void TestVerificacionDelValorDeAtaqueDelSoldado()
        {
            Assert.That(_soldier.AttackValue, Is.EqualTo(80));
        }
        
        [Test]
        public void TestVerificacionDeValorDeDefensaDelSoldado()
        {
            Assert.That(_soldier.DeffenseValue, Is.EqualTo(54));
        }
        
        [Test]
        public void TestVerificacionDeValorDeVelocidadDelSoldado()
        {
            Assert.That(_soldier.Speed, Is.EqualTo(23));
        }
    }
}