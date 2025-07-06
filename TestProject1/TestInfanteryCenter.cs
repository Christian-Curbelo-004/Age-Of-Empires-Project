using ClassLibrary1.BuildingsDirectory;
using NUnit.Framework;
namespace TestProject1;

public class TestInfanteryCenter
{
    private InfanteryCenter _centerInf;

    [Test]
    public void InfanteryCenterTest()
    {
        int expectedendurence = 20;
        int expectedConstructionTimeleft = 10;
        string expectedname = "InfanteryCenter";
        int expectedOwnerId = 1223;

        _centerInf = new InfanteryCenter (20, 10, "InfanteryCenter",1223);

        Assert.AreEqual("InfanteryCenter",expectedname, _centerInf.Name);
        Assert.AreEqual(10, expectedConstructionTimeleft, _centerInf.ConstructionTime);
        Assert.AreEqual(20, expectedendurence, _centerInf.Endurence);
        Assert.IsEqual(1223, expectedOwnerId, _centerInf.OwnerId);
    }
}