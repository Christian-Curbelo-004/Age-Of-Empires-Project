using GameModels;
namespace ClassLibrary1.LogicDirectory;

public interface IWorkTarget
{
    GameResourceType ResourceType { get; }
    int ExtractResources(int collectors);
    bool IsEmpty { get; }
}