
using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.CivilizationDirectory;

public class Chivarly : Soldier, IMapEntity                                
{
    
    public Chivarly() : base(100, 20, 15,20)
    {
    }
    public string Symbol { get; set; } = "Ch";
    public override int Attack(ICharacter target) //Ataque
    {
        return target.RecieveAttack(AttackValue);
    }

    public override int RecieveAttack(int damage) //Recibir Ataque
    {
        Life -= damage;
        return Life;
    }
}