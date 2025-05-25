namespace ClassLibrary1;

public interface IPersonaje
{
     int Life { get; set; }
     int AttackValue { get; set; }
     
     void Attack(IPersonaje target);
     void RecieveAttack(int damage);
}
    