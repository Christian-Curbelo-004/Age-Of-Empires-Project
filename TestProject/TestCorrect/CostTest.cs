using ClassLibrary1.LogicDirectory;

namespace TestProject.TestCorrect;

[TestFixture]
public class CostTest
{
    public class CostTestCorrect : Cost
    {
        public CostTestCorrect(int food, int wood, int gold, int stone) : base(food, wood, gold, stone)
        {
            Food = 100;
            Wood = 1000;
            Gold = 10000;
            Stone = 100000 ;
        }
    }
    
    private Cost _cost;

    [SetUp]
    public void Setup()
    {
        _cost = new CostTestCorrect(100, 1000, 10000, 100000);
    }
    
    [Test]
    public void TestDeLaVerificacionDelCostoDeLaComida()
    {
        Assert.That(_cost.Food, Is.EqualTo(100));
    }
    
    [Test]
    public void TestDeLaVerificacionDelCostoDeMadera()
    {
        Assert.That(_cost.Wood, Is.EqualTo(1000));
    }
    
    [Test]
    public void TestDeLaVerificacionDelCostoDeOro()
    {
        Assert.That(_cost.Gold, Is.EqualTo(10000));
    }
    
    [Test]
    public void TestDeLaVerificacionDelCostoDePiedra()
    {
        Assert.That(_cost.Stone, Is.EqualTo(100000));
    }
}