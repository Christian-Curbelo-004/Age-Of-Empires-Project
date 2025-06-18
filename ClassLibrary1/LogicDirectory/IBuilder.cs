using CreateBuildings;
namespace ClassLibrary1.CivilizationDirectory;

public interface IBuilder
{
    bool Build(Buildings target,int builders);
}