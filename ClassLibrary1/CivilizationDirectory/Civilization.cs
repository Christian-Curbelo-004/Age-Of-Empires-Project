using System.Collections.Generic;
namespace ClassLibrary1
{
    public abstract class Civilization
    {
        public List<Villagers> Villagers { get  ; set; }
        public List<Soldier> Soldiers { get ; set; }
        public List<ICharacter> Units { get ; set; }
        
        public Civilization()
        {
            Villagers = new List<Villagers>();
            Soldiers = new List<Soldier>();
            Units = new List<ICharacter>();
        }
       
        public abstract ICharacter PickUnit(string unitName);
    }
}