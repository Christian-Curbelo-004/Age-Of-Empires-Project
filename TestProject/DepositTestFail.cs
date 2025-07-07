using ClassLibrary1.DepositDirectory;

namespace TestProject;

[TestFixture]
public class DepositTestFail
{
    public class DepositTest : Deposit
    {
        public DepositTest(int endurence, int constructiontimeleft, string name, int maxCapacity) : base(endurence,
            constructiontimeleft, name, maxCapacity)
        {
            ConstructionTime = 1000;
            IsConstructed = false;
            OwnerId = 1234;
            Position = (0, 0);
        }
    }

    private DepositTest _depositTest;

    [SetUp]
    public void Setup()
    {
        _depositTest = new DepositTest(100, 1000, "DepositTest", 100);
    }

    [Test]
    public void TestDeResistenciaDelDeposito()
    {
        Assert.That(_depositTest.Endurence, Is.EqualTo(100));
    }

    [Test]
    public void TestDeTiempoDeConstruccionDelDeposito()
    {
        Assert.That(_depositTest.ConstructionTime, Is.EqualTo(1000));
    }

    [Test]
    public void TestDeVerificacionDelNombreDelDeposito()
    {
        Assert.That(_depositTest.Name, Is.EqualTo("Galpon"));
    }

    [Test]
    public void TestDeVerificacionDeLaCapacidadMaximaDelDeposito()
    {
        Assert.That(_depositTest.MaxCapacity, Is.EqualTo(0));
    }
}