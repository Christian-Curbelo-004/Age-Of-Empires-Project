using System.Collections.Generic;
using System;
using GameResourceType = GameModels.GameResourceType;

namespace ClassLibrary1.CivilizationDirectory


{
    public class Raider : Soldier, ICharacter
    {
        public override int Life { get; set; }
        public override  int AttackValue { get; set; }
        public override int DeffenseValue { get; set; }
        // public int Speed { get; set; }
        public Dictionary<GameResourceType, int> ConstructionCost { get;  set; } = new ();


        public Raider() : base(100, 33,25,15)
        {
        }
        public void GetCreate(Dictionary<string,int>GetCost)
        {
            ConstructionCost[GameResourceType.Stone] = 100;
            ConstructionCost[GameResourceType.Gold] = 40;
            ConstructionCost[GameResourceType.Wood] = 150;
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