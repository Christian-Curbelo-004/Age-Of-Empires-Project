using ClassLibrary1.BuildingsDirectory;
namespace TestProject1;

public class TestInfanteryCenter
{
    private InfanteryCenter centerInf;

    [SetUp]
    public void Setup()
    {
        centerInf = new InfanteryCenter (20, 10, "InfanteryCenter");
        
    }

    [Test]
    public void ConstructionCostCorrect()
    {
        var constructionCost = new Dictionary<string, int>();
        centerInf.GetConstructionCost();
        Assert.That(constructionCost["Piedra"],Is.EqualTo(10));
        Assert.That(constructionCost["Oro"],Is.EqualTo(6));
    }
    [Test]
    public void ConstructionCostIncorrect()
    {
        var constructionCost = new Dictionary<string, int>();
        centerInf.GetConstructionCost();
    }
    
}