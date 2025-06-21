using ClassLibrary1.CivilizationDirectory;

namespace ClassLibrary1.LogicDirectory;

public interface ILogic
{
    void CentersLogic(PlayerOne player);
    void DepositLogic();
    void MinesLogic();
    void VillagersLogic(PlayerOne player);
}