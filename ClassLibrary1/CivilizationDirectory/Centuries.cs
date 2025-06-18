using System.Collections.Generic;
using System;

namespace ClassLibrary1
{
    public class Centuries : ICharacter
    {
        public int Life { get; set; }
        public int AttackValue { get; set; }
        public int DeffenseValue { get; set; }
        public int Speed { get; set; }


        public Centuries()
        {
            Life = 100;
            AttackValue = 10;
            DeffenseValue = 40;
            Speed = 12;
        }
        public void GetCreate(Dictionary<string,int>GetCost)
        {
            GetCost["Oro"] = 13;
            GetCost["Piedra"] = 60;
        }
        public int Attack(ICharacter target)
        {
            return target.RecieveAttack(AttackValue);
        }

        public int RecieveAttack(int damage)
        {
            DeffenseValue -= damage;
            return DeffenseValue;
        }

        public int BoostAttack(ICharacter target)
        {
            AttackValue += 10;
            return target.RecieveAttack(BoostAttack(target));
        }
    }
}
