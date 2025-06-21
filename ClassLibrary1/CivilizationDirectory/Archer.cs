namespace ClassLibrary1.CivilizationDirectory;

public class Archer : Soldier
{
    public Archer() : base(100,15, 0,20)
    {
    }
    
    public override int Attack(ICharacter target)
    {
        return target.RecieveAttack(AttackValue);
    }

    public override  int RecieveAttack(int damage)
    {
        Life -= damage;
        return Life;
    }

    public string? Run(string direction)
    {
        if (direction.ToLower() == "izquierda" || direction.ToLower() == "derecha" || direction.ToLower() == "sube" ||
            direction.ToLower() == "baja") 
        {
            Speed += 10;
            return direction;
        }
        return null;
    }
}