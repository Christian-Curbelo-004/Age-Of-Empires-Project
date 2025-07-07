namespace TestProject
{
    public class TestQuaries
    {

        private class TesterQuaries : Quary
        {
            public override string ResourceType => "TestResource";
            public TesterQuaries(int ownerId, int extractionRate, int collectionValue, int initialAmount)
                : base(ownerId, extractionRate, collectionValue, initialAmount)
            {
                OwnerId = 1234;
                ExtractionRate = 60;
                CollectionValue = 100;
                CurrentAmount = 0;
            }
        }
        
        private Quary _quary;

        [SetUp]
        public void Setup()
        {
            _quary = new TesterQuaries(1234, 60, 100, 0);
        }

        [Test]
        public void TestDeVerificacionDeLaIdDelJugadorUno()
        {
            Assert.That(_quary.OwnerId, Is.EqualTo(1234));
        }
        [Test]
        public void TestDeVerificacionDeRecoleccion()
        {
            Assert.That(_quary.ExtractionRate, Is.EqualTo(60));
        }

        [Test]
        public void TestDeVerificacionDeCantidadDeRecoleccion()
        {
            Assert.That(_quary.CollectionValue, Is.EqualTo(100));
        }

        [Test]
        public void TestDeVerificacionDeMontoInicial()
        {
            Assert.That(_quary.CurrentAmount, Is.EqualTo(0));
        }
    }
}