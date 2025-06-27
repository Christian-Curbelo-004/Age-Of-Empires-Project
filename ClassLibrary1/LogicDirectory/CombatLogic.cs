using System.Reflection.Metadata.Ecma335;
using ClassLibrary1.CivilizationDirectory;

namespace ClassLibrary1.LogicDirectory;

public static class CombatLogic
{
    public static int Damage(ICharacter attacker, ICharacter target)
    {

        target.Life -= attacker.AttackValue;
        
        if(target.Life < 0)
            target.Life = 0;

        return target.Life;
    }
}