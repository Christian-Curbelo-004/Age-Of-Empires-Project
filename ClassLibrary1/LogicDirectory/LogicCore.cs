
using ClassLibrary1.CivilizationDirectory;
namespace ClassLibrary1.LogicDirectory;

public abstract class LogicCore : ILogic
{
    // Los centros tienen que crear su respectivo soldado si tiene los recuros.
    // Luego de crearlo hay que hacer que el aldeano deje de ser aldeano.
    // Evaluar si hay espacio en la casa Soldado.
    // sumar los aldeanos que se pueden crear en la casa del aldeano y restar la capacidad de la casa soldier.
    public void CentersLogic(PlayerOne player)
    {
        void CreateSoldier(Soldier soldier)
        {
            var cost = soldier.GetCreate();
            if (player.HasResources(cost))
            {
                player.SpendResources(cost);
                player.AddSoldier(soldier);
            }
        }
        CreateSoldier(UnitFactory.CreateInfantery());
        CreateSoldier(UnitFactory.CreateArcher());
        CreateSoldier(UnitFactory.CreateChivarly());
    }

    public void DepositLogic()
    {
    }

    public void MinesLogic()
    {
    }

    public void VillagersLogic()
    {
    }
}