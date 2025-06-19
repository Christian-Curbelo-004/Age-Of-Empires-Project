using System.Collections.Generic;
using System;

namespace ClassLibrary1


{
    public class Raider : Soldier, ICharacter
    {
        public int Life { get; set; }
        public int AttackValue { get; set; }
        public int DeffenseValue { get; set; }
        public int Speed { get; set; }


        public Raider() : base(100, 33,25,15)
        {
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