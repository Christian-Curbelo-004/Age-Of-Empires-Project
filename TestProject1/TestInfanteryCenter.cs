using ClassLibrary1.BuildingsDirectory;
namespace TestProject1;

public class TestInfanteryCenter
{
    private InfanteryCenter _centerInf;

    [SetUp]
    public void Setup()
    {
        _centerInf = new InfanteryCenter (20, 10, "InfanteryCenter",1223);
    }

    [Test]
    public void ConstructionCostCorrect()
    {
        var constructionCost = _centerInf.GetConstructionCost();
        Assert.That(constructionCost["Piedra"],Is.EqualTo(10));
        Assert.That(constructionCost["Oro"],Is.EqualTo(20));
    }
}