using ClassLibrary1.MapDirectory;

public interface ITrainingBuilding : IMapEntity
{
    IMapEntity CreateUnit(string troopType);
}