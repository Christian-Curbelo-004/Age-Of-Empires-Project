using ClassLibrary1.BuildingsDirectory;


namespace TestProject.TestFail;

public class BuildingsTestsFail
{

    public class BuildingsTestFail : Buildings
    {
        public BuildingsTestFail(int endurence, string name) : base(endurence, name)
        {
            ConstructionTime = 1000;
            IsConstructed = false;
            OwnerId = 1234;
            Position = (0, 0);
        }
    }


    private BuildingsTestFail _building;

    [SetUp]
    public void Setup()
    {
        _building = new BuildingsTestFail(80, "Building");
    }

    [Test]
    public void TestDeDurabilidadDeLaConstruccion()
    {
        Assert.That(_building.Endurence, Is.EqualTo(8));
    }

    [Test]
    public void TestDeNombreCorrectoDeLaConstruccion()
    {
        Assert.That(_building.Name, Is.EqualTo("Building"));
    }

    [Test]
    public void TestDelTiempoCorrectoDeLaConstruccion()
    {
        Assert.That(_building.ConstructionTime, Is.EqualTo(1));
    }

    [Test]
    public void TestDeVerificacionDeLaConstruccion()
    {
        Assert.That(_building.IsConstructed, Is.EqualTo(false));
    }

    [Test]
    public void TestDeLaVerificacionDeLaIdDelJugadorUno()
    {
        Assert.That(_building.OwnerId, Is.EqualTo(1234));
    }

    [Test]
    public void TestDeLaPosicionCorrectaDeLaConstruccion()
    {
        Assert.That(_building.Position, Is.EqualTo((0,0)));
    }
}