using ClassLibrary1.UnitsDirectory;

namespace TestProject;

public class 
    TestCivilization
{
    [Test]
    public void PropiedadesDeVillager()
    {
        // Arrange
        var villager = new Villagers(100, 40, 1, 10);

        // Assert
        Assert.That(villager.Life, Is.EqualTo(100));
        Assert.That(villager.AttackValue, Is.EqualTo(40) );
        Assert.That(villager.OwnerId, Is.EqualTo(1));
        Assert.That(villager.Speed, Is.EqualTo(10));
    }
}