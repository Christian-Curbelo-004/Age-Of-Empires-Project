using ArcherCenter_;
using ClassLibrary1.CivilizationDirectory;
using GameModels;
using ClassLibrary1.DepositDirectory;
namespace ClassLibrary1.LogicDirectory;

public abstract class LogicCore : ILogic
{
    public void CentersLogic()
    {
        // Los centros tienen que crear su respectivo soldado si tiene los recuros.
        // Luego de crearlo hay que hacer que el aldeano deje de ser aldeano.
        // Evaluar si hay espacio en la casa Soldado.
        // sumar los aldeanos que se pueden crear en la casa del aldeano y restar la capacidad de la casa soldier.
        ArcherCenter archerCenter = new ArcherCenter(20, 10, "Archer Center");
        archerCenter.SetConstructionCost();
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