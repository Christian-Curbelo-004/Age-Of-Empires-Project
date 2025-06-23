namespace ClassLibrary1.CivilizationDirectory;

public class Roman : Civilization
{
    public Roman()
    {
        Units.Add(new Centuries());
    }

    public override ICharacter PickUnit(string unitName)
    {
        return unitName.ToLower() switch
        {
            "Centuries" => new Centuries(),
            _ => null,
        };
    }
}
    