using System.Collections.Generic;
using InfanteryCenter;  
using NUnit.Framework; 

namespace TestProject1;

public class TestsInfanteyCenter
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
        Assert.AreEqual(100, constructionCost["Madera"]);
        Assert.AreEqual(20, constructionCost["Oro"]);
    }
}
