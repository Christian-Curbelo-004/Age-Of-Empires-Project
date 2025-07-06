using ClassLibrary1.BuildingsDirectory;

namespace TestProject;

public class BuildingsTests
{
    
    public class TestBuilding : Buildings
    {
        public TestBuilding(int endurence, string name) : base(endurence, name)
        {
            ConstructionTime = 1000;
            IsConstructed = false;
            OwnerId = 1234;
        }
    }
    [Test]
    public void TestBuildingCreation()
    {
        var building = new TestBuilding(80, "Buildings");

        Assert.That(building.Endurence, Is.EqualTo(80));
        Assert.That(building.Name, Is.EqualTo("Buildings"));
        Assert.That(building.Position, Is.EqualTo((0, 0)));
        Assert.That(building.ConstructionTime, Is.EqualTo(1000));
        Assert.That(building.IsConstructed, Is.False);
        Assert.That(building.OwnerId, Is.EqualTo(1234));
    }
}

