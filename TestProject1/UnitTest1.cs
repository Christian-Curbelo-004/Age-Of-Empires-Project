using System.Collections.Generic;
using InfanteryCenter;  
using NUnit.Framework; 

namespace TestProject1;

public class TestsChivarlyCenter
{
    private ChivarlyCenter.ChivarlyCenter center;
    [SetUp]
    public void Setup()
    {
        center = new ChivarlyCenter.ChivarlyCenter(20, 10, "ChivarlyCenter", 100);
    }

    [Test]
    public void ConstructionCost()
    {
        
        var constructionCost = new Dictionary<string, int>();
        center.GetconstructionCost(constructionCost);
        //Assert.AreEquals(100, constructionCost["Madera"]);
        Assert.That(constructionCost["Oro"],Is.EqualTo(20));
        Assert.That(constructionCost["Madera"],Is.EqualTo(100));
        //Assert.AreEquals(20, constructionCost["Oro"]);
    }

    [Test]
    public void ConstructionTime()
    {
        int constructionTime = center.GetConstuctionTime(0);
        Assert.That(constructionTime, Is.EqualTo(20));
    }
}
