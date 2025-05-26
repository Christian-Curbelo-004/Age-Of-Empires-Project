namespace ClassLibrary1;

public interface ICharacter
{
     int Life { get; set; }
     int AttackValue { get; set; }
     
     void Attack(ICharacter target);
     void RecieveAttack(int damage);
}
    