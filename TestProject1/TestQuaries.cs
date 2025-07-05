using NUnit.Framework;

namespace TestProject1
{
    public class TestQuaries
    {
   
        private class TesterQuaries : Quary
        {
            public TesterQuaries(int ownerId, int extractionRate, int collectionValue, int initialAmount)
                : base(ownerId, extractionRate, collectionValue, initialAmount)
            {
            }
        }

        [Test]
        public void TestGetResource()
        {
            // Arrange
            var quary = new TesterQuaries(1, 100, 20, 32);

            // Act
            int resources = quary.GetResources(1);

            // Assert
            Assert.That(resources, Is.EqualTo(100));
        }
    }
}