using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.CivilizationDirectory.CharactersDirectory;

public interface IMovable : IMapEntity
{
    int Speed { get; }
}
