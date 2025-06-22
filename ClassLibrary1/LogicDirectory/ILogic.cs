using ClassLibrary1.CivilizationDirectory;

namespace ClassLibrary1.LogicDirectory;

public interface ILogic
{
    void CentersLogic(PlayerOne player);
    void DepositLogic(PlayerOne player);
    void VillagersLogic(PlayerOne player);
}