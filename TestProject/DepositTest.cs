using ClassLibrary1.DepositDirectory;

namespace TestProject;

public class TestDeposit
{
    private class TesterDeposit : Deposit
    {
        public TesterDeposit(int endurence, int constructiontimeleft, string name, int maxCapacity)
            : base(endurence, constructiontimeleft, name, maxCapacity)
        {
        }
    }

    [Test]
    public void ActualResourcesTest() //Arreglar esto
    {
        var deposit = new TesterDeposit(10, 10, "deposit", 10);
        deposit.CurrentStorage = 150;
        
        Assert.That(deposit.CurrentStorage, Is.EqualTo(150));
    }
}