using ClassLibrary1.FacadeDirectory;

namespace ClassLibrary1.LogicDirectory;

public interface ILogic
{
    void CentersLogic(Player playerOne);
    void DepositLogic(Player playerOne);
    void VillagersLogic(Player playerOne);
}