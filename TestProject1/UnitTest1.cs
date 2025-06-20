using System.Collections.Generic;
//using InfanteryCenter;  
using NUnit.Framework; 



namespace TestProject1;

public class TestsChivarlyCenter
{
    private ChivarlyCenter.ChivarlyCenter center;
    [SetUp]
    public void Setup()
    {
        center = new ChivarlyCenter.ChivarlyCenter(20, 10, "ChivarlyCenter");
    }

    [Test]
    public void ConstructionCost()
    {
        var constructionCost = new Dictionary<string, int>();
        Assert.That(constructionCost["Madera"],Is.EqualTo(100));
        Assert.That(constructionCost["Oro"],Is.EqualTo(20));
    }
}
