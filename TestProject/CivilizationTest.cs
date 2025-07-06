
using ClassLibrary1.UnitsDirectory;

namespace TestProject;

public class TestCivilization
{
    private Villagers _villagers;

    [SetUp]
    public void Setup()
    {
        _villagers = new Villagers(100, 4, 1, 10);
    }


    [Test]
    public void TestDeLaVidaDelAldeano()
    {
        Assert.That(_villagers.Life, Is.EqualTo(100));
    }

    [Test]
    public void TestDelAtaqueDelAldeano()
    {
        Assert.That(_villagers.AttackValue, Is.EqualTo(4));
    }

    [Test]
    public void TestDeLaIdDelJugadorUno()
    {
        Assert.That(_villagers.OwnerId, Is.EqualTo(1));
    }

    [Test]
    public void TestDeLaVelocidadDelAldeano()
    {
        Assert.That(_villagers.Speed, Is.EqualTo(10));
    }
}
