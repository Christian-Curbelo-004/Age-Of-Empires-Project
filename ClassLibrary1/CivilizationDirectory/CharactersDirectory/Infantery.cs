using ClassLibrary1.MapDirectory;

namespace ClassLibrary1.CivilizationDirectory;

public class Infantery : Soldier, IMapEntity                                          
{
    public Infantery() : base(100,14,10,13)
    {
    }
    public string Symbol { get; set; } = "In";
    public override string ToString()
    {
        return $"{Symbol}{OwnerId}"; 
    }
    public override int Attack(ICharacter target) //Atacar
    {
        return target.RecieveAttack(AttackValue);
    }

    public override  int RecieveAttack(int damage) // Recibir Ataque
    {
        Life -= damage;
        return Life;
    }
    
}
