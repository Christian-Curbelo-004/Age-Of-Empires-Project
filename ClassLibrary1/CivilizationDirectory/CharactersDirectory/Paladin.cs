
using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.CivilizationDirectory;


public class Paladin : Soldier, IMapEntity                               
{
    public Paladin() : base(100, 25,  40,9) 
    {
    }
    public string Symbol { get; set; } = "Pl";
    public override string ToString()
    {
        return $"{Symbol}{OwnerId}"; 
    }
    public override int Attack(ICharacter target) // Atacar
    {
        return target.RecieveAttack(AttackValue);
    }

    public override  int RecieveAttack(int damage) // Recibir ataque
    {
        DeffenseValue -= damage;
        return DeffenseValue;
    }

    public  int Boost(int damage) // Buffeo
    {
        DeffenseValue += 15;
        return Boost(damage);
    }

}