using System.Net.Sockets;
//falta implementarla en el program 
namespace ClassLibrary1.CivilizationDirectory;

public class CombatAdvantages
{
    public static List<(string attack, string deffend, float dañoventaja)> advantages =
        new List<(string, string, float)>
        {
            ("Archer", "Infantery", 1.5f), ("Archer", "Viking", 1.1f), ("Roman", "Soldier", 1.3f),
            ("Templaries", "Archer", 1.2f), ("Raider", "Templaries", 1.8f)
        };

    public static float GetAddvantage(ICharacter attack, ICharacter deffend)
    {
        string attackName = attack.GetType().Name;
        string deffendName = deffend.GetType().Name;

        foreach (var i in advantages)
        {
            if (i.attack == attackName && i.deffend == deffendName)
            {
                return i.dañoventaja;
            }
        }

        return 1.0f; //ya que al no haber ningun tipo de ventaja, se ejecuta el daño normal
    }

}