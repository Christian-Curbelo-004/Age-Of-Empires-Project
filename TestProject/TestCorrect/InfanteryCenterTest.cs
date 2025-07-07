
using ClassLibrary1.BuildingsDirectory;


namespace TestProject
{
    public class TestInfanteryCenter
    {
        private InfanteryCenter? _centerInf;
        

        [SetUp]
        public void Setup()
        {
            _centerInf = new InfanteryCenter(20, 10, "InfanteryCenter", 1223);
        }

        [Test]
        public void TestDeVerificacionDeResistenciaDelInfanteryCenter()
        {
            Assert.That(_centerInf.Endurence, Is.EqualTo(20));
        }

        [Test]
        public void TestDeVerificacionDelTiempoDeConstruccion()
        {
            Assert.That(_centerInf.ConstructionTime, Is.EqualTo(10));
        }

        [Test]
        public void TestDeVerificaiconDelNombreCorrectoDeLaConstruccion()
        {
            Assert.That(_centerInf.Name, Is.EqualTo("InfanteryCenter"));
        }

        [Test]
        public void TestDeVerificacionDeLaIdDelJugadorUno()
        {
            Assert.That(_centerInf.OwnerId, Is.EqualTo(1223));
        }

    }
}