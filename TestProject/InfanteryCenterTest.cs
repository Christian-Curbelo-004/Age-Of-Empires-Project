
using ClassLibrary1.BuildingsDirectory;


namespace TestProject
{
    public class TestInfanteryCenter
    {
        private InfanteryCenter? _centerInf;
        
        [Test]
        public void InfanteryCenterTest()
        {
            int expectedendurence = 20;
            int expectedConstructionTimeleft = 10;
            string expectedname = "InfanteryCenter";
            int expectedOwnerId = 1223;

            _centerInf = new InfanteryCenter(20, 10, "InfanteryCenter", 1223);

            Assert.That(_centerInf.Name, Is.EqualTo(expectedname));
            Assert.That(_centerInf.ConstructionTime, Is.EqualTo(expectedConstructionTimeleft));
            Assert.That(_centerInf.Endurence, Is.EqualTo(expectedendurence));
            Assert.That(_centerInf.OwnerId, Is.EqualTo(expectedOwnerId));
        }
    }
}