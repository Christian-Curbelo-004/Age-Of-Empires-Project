
using ClassLibrary1.BuildingsDirectory;

namespace TestProject2
{
    public partial class TestInfanteryCenter
    {
        private InfanteryCenter _centerInf;

        public TestInfanteryCenter(InfanteryCenter centerInf)
        {
            _centerInf = centerInf;
        }

        [Test]
        public void InfanteryCenterTest()
        {
            int expectedendurence = 20;
            int expectedConstructionTimeleft = 10;
            string expectedname = "InfanteryCenter";
            int expectedOwnerId = 1223;

            _centerInf = new InfanteryCenter(20, 10, "InfanteryCenter", 1223);

            Assert.ReferenceEquals(expectedname, _centerInf.Name);
            Assert.ReferenceEquals(expectedConstructionTimeleft, _centerInf.ConstructionTime);
            Assert.ReferenceEquals(expectedendurence, _centerInf.Endurence);
            Assert.ReferenceEquals(expectedOwnerId, _centerInf.OwnerId);
        }
    }
}