using System;
using System.Collections.Generic;

namespace ClassLibrary1.CivilizationDirectory;



public class Roman : Civilization
{
    public Roman()
    {
        Units.Add(new Archer());
    }

    public override ICharacter PickUnit(string unitName)
    {
        return unitName.ToLower() switch
        {
            "Archer" => new Archer(),
            _ => null,
        };
    }
}
    