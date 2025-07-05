using ClassLibrary1.DepositDirectory;
namespace ClassLibrary1.LogicDirectory;

public class DepositLogic : Deposit
{ 
    // Hay que mejorar esto
    public bool IsOccupied { get; set; }

    public DepositLogic(int endurence, int constructiontimeLeft, string name, int maxCapacity)
        : base(endurence, constructiontimeLeft, name, maxCapacity)
    {
        if (maxCapacity < CurrentStorage)
        {
            IsOccupied = false;
        }
        else
        {
            IsOccupied = true;
        }

    }
}