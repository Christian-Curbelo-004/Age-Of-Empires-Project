using System.Collections.Generic;
using System;



namespace ClassLibrary1.CivilizationDirectory;

public class Viking : Civilization
{
    public Viking()
    {
        Units.Add(new Raider());
    }
    public override ICharacter PickUnit(string unitName)
    {
        return unitName.ToLower() switch
        { 
            "Raider" => new Raider(),
            _ => null
        };
    }
    
}
