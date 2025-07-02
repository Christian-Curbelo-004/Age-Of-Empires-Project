using NUnit.Framework;

namespace TestProject1
{
    public class TestQuaries
    {
   
        private class TesterQuaries : Quary
        {
            public TesterQuaries(int ownerId, int extractionRate, int collectionValue, int initialAmount, string resourceType)
                : base(ownerId, extractionRate, collectionValue, initialAmount, resourceType)
            {
            }
        }

        [Test]
        public void TestGetResource()
        {
            // Arrange
            var quary = new TesterQuaries(1, 100, 20, 32, "piedra");

            // Act
            int resources = quary.GetResources();

            // Assert
            Assert.That(resources, Is.EqualTo(100));
        }
    }
}