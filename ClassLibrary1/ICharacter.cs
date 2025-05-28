namespace ClassLibrary1;

public interface ICharacter
{
     int Life { get; set; }
     int AttackValue { get; set; }
     
     int Attack(ICharacter target);
     int RecieveAttack(int damage);
}
    