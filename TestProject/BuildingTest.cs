using ClassLibrary1.BuildingsDirectory;


namespace TestProject;

public class BuildingsTests
{

    public class BuildingsTest : Buildings
    {
        public BuildingsTest(int endurence, string name) : base(endurence, name)
        {
            ConstructionTime = 1000;
            IsConstructed = false;
            OwnerId = 1234;
            Position = (0, 0);
        }
    }


    private BuildingsTest _building;

    [SetUp]
    public void Setup()
    {
        _building = new BuildingsTest(80, "Building");
    }

    [Test]
    public void TestDeDurabilidadDeLaConstruccion()
    {
        Assert.That(_building.Endurence, Is.EqualTo(80));
    }

    [Test]
    public void TestDeNombreCorrectoDeLaConstruccion()
    {
        Assert.That(_building.Name, Is.EqualTo("Building"));
    }

    [Test]
    public void TestDelTiempoCorrectoDeLaConstruccion()
    {
        Assert.That(_building.ConstructionTime, Is.EqualTo(1000));
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