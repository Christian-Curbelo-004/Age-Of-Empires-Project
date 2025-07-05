using ClassLibrary1.CivilizationDirectory.CharactersDirectory;

namespace ClassLibrary1.CivilizationDirectory;

public class Templaries : Civilization
{
    public Templaries()
    {
        Units.Add(new Paladin());
    }
    public override ICharacter PickUnit(string unitName)
    {
        return unitName.ToLower() switch
        {

            "Paladin" => new Paladin(),
            _ => null
        };
    }
}


