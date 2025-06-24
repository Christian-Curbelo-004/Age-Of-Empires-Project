namespace ClassLibrary1.LogicDirectory;

public interface IWorkTarget
{
  
    int ExtractResources(int collectors);
    bool IsEmpty { get; }
}