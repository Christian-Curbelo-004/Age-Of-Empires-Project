using System.Collections.Generic;
using System;

namespace ClassLibrary1


{
    public class Raider : ICharacter
    {
        public int Life { get; set; }
        public int AttackValue { get; set; }
        public int DeffenseValue { get; set; }


        public Raider()
        {
            Life = 100;
            AttackValue = 33;
            DeffenseValue = 25;
        }
        public void GetCreate(Dictionary<string,int>GetCost)
        {
            GetCost["Oro"] = 5;
            GetCost["Piedra"] = 40;
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