using ClassLibrary1.DepositDirectory;
namespace ClassLibrary1.LogicDirectory;

public class DepositLogic : Deposit
{
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
    

/* otra solucion
 
 * public class DepositLogic : Deposit
{
    public bool IsOccupied => CurrentStorage >= MaxCapacity;

    public DepositLogic(int endurence, int constructiontimeLeft, string name, int maxCapacity)
        : base(endurence, constructiontimeLeft, name, maxCapacity)
    {
        // no se necesita lógica aquí, IsOccupied se calcula sola
    }
}

 */

