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
/*
    public string Attack(ICharacter attacker, ICharacter target)
        {
            int vidaObjetivo = CombatLogic.Damage(attacker, target);
            string mensaje = $"La vida restante del objetivo es {vidaObjetivo}";

            if (vidaObjetivo < 0)
                mensaje += ". El objetivo ha sido derrotado";
            return mensaje;
        }
*/