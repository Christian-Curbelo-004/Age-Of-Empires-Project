using System.Collections.Generic;
using System;
using GameResourceType = GameModels.GameResourceType;

namespace ClassLibrary1.CivilizationDirectory


{
    public class Raider : Soldier, ICharacter
    {
        public Raider() : base(100, 33,25,15)
        {
        }
        public void GetCreate(Dictionary<string,int>GetCost)
        {
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
            return target.RecieveAttack(AttackValue);
        }
    }
}