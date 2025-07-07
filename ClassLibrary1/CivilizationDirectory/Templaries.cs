namespace ClassLibrary1.CivilizationDirectory;

public class Templaries : Civilization
{
    public Player Player { get; set; }
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


