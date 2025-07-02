using ClassLibrary1.DepositDirectory;

namespace TestProject1;

public class TestDeposit
{
    private class TesterDeposit : Deposit
    {
        public TesterDeposit(int endurence, int constructiontimeleft, string name, int maxCapacity)
            : base(endurence, constructiontimeleft, name, maxCapacity)
        {
        }

        public override int ActualResources()
        {
            return CurrentStorage;
        }
    }

    [Test]
    public void ActualResourcesTest()
    {
        var deposit = new TesterDeposit(10, 10, "deposit", 10);
        deposit.CurrentStorage = 150;
        
        Assert.That(deposit.ActualResources(), Is.EqualTo(150));
    }
}