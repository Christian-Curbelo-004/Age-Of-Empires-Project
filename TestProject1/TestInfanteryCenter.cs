using System;
using System.Collections.Generic;
using InfanteryCenter;  
using NUnit.Framework;



namespace TestProject1;

public class TestInfanteryCenter
{
    private InfanteryCenter.InfanteryCenter centerInf;

    [SetUp]
    public void Setup()
    {
        centerInf = new InfanteryCenter.InfanteryCenter(20, 10, "InfanteryCenter", 100);
        
    }

    [Test]
    public void ConstructionCostCorrect()
    {
        var constructionCost = new Dictionary<string, int>();
        centerInf.GetConstructionCost(constructionCost);
        Assert.That(constructionCost["Piedra"],Is.EqualTo(10));
        Assert.That(constructionCost["Oro"],Is.EqualTo(6));
    }
    [Test]
    public void ConstructionCostIncorrect()
    {
        var constructionCost = new Dictionary<string, int>();
        centerInf.GetConstructionCost(constructionCost);
        //int time = centerInf.GetConstructionTime(0);
        //Assert.That(time, Is.EqualTo(6));
    }
    
}