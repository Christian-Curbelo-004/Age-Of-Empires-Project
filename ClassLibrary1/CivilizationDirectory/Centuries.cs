using System.Collections.Generic;
using System;
using GameResourceType = GameModels.GameResourceType;
namespace ClassLibrary1.CivilizationDirectory
{
    public class Centuries : Soldier
    {
        public override int Life { get; set; }
        public override  int AttackValue { get; set; }
        public override int DeffenseValue { get; set; }
        public Dictionary<GameResourceType, int> ConstructionCost { get;  set; } = new ();

        public Centuries() : base(100, 10, 40,12)
        {
        }
        public override  void GetCreate(Dictionary<string,int>getCost)
        {
        }
        public override int Attack(ICharacter target)
        {
            return target.RecieveAttack(AttackValue);
        }

        public override int RecieveAttack(int damage)
        {
            DeffenseValue -= damage;
            return DeffenseValue;
        }

        public  int BoostAttack(ICharacter target)
        {
            AttackValue += 10;
            return target.RecieveAttack(AttackValue);
        }
    }
}
