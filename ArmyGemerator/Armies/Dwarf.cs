using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class Dwarf : BaseArmy
    {
        public Dwarf() : base()
        {
            armyNumber = 5;
            name = "Dwarves";
            soldiers.Add(new BaseSoldiers(3, 4, 5, 5, 5, 5, 3, 5, "Dwarf Militia", armyNumber));
            soldiers.Add(new BaseSoldiers(6, 4, 4, 5, 4, 4, 3, 5, "Dwarf Warrior", armyNumber));
            soldiers.Add(new BaseSoldiers(9, 3, 4, 5, 4, 3, 3, 5, "Dwarf Veteran", "Drilled", armyNumber));
            soldiers.Add(new BaseSoldiers(9, 3, 4, 5, 3, 4, 3, 5, "Dwarf Barbarian", "Bravery", armyNumber));
            soldiers.Add(new BaseSoldiers(11, 3, 4, 5, 3, 3, 3, 5, "Dwarf Elite", "Drilled, Bravery", armyNumber));
            soldiers.Add(new Artilleryman(6, 4, 4, 5, 4, 4, 3, 5, "Artillerydwarf", armyNumber));
            soldiers.Add(new BaseHero(30, 3, 3, 5, 3, 3, 3, 3, "Dwarf Captain", 3, 3, armyNumber));
            soldiers.Add(new BaseHero(50, 4, 4, 5, 4, 5, 3, 5, "Dwarf Sage", 6, 2, 2, 2, armyNumber));
        }
    }
}
