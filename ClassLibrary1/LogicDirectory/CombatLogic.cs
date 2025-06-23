using System.Reflection.Metadata.Ecma335;
using ClassLibrary1.CivilizationDirectory;

namespace ClassLibrary1.LogicDirectory;

public class CombatLogic
{
    public string Combat(ICharacter attacker, ICharacter target)
    {

        target.Life -= attacker.AttackValue;
        return target.Life.ToString();
    }
}