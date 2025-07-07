using ClassLibrary1.CivilizationDirectory.CharactersDirectory;

namespace ClassLibrary1.CivilizationDirectory;
public class Viking : Civilization
{
    public Player Player { get; set; }
    public Viking()
    {
        Units.Add(new Raider());
    }
    public override ICharacter PickUnit(string unitName)  // Elegir la unidad
    {
        return unitName.ToLower() switch
        { 
            "Raider" => new Raider(),
            _ => null
        };
    }
    
}
