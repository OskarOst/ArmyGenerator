using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class Elf : BaseArmy
    {
        public Elf() : base()
        {
            armyNumber = 6;
            name = "Elves";
            soldiers.Add(new BaseSoldiers(4, 4, 3, 6, 5, 5, 5, 8, "Elf Militia", armyNumber));
            soldiers.Add(new BaseSoldiers(7, 3, 3, 6, 4, 4, 5, 8, "Elf-at-arms", armyNumber));
            soldiers.Add(new BaseSoldiers(11, 2, 3, 6, 4, 3, 5,8, "Elven Veteran", "Drilled", armyNumber));
            soldiers.Add(new BaseSoldiers(11, 2, 3, 6, 3, 4, 5, 6, "Elven Knight", "Bravery", armyNumber));
            soldiers.Add(new BaseSoldiers(14, 2, 2, 6, 3, 3, 5, 8, "Elven Elite", "Drilled, Bravery", armyNumber));
            soldiers.Add(new Artilleryman(7, 3, 3, 6, 4, 4, 5, 8, "Artileryelf", armyNumber));
            soldiers.Add(new BaseHero(40, 2, 2, 6, 3, 3, 5, 8, "Elven Noble", 4, 3, armyNumber));
            soldiers.Add(new BaseHero(65, 3, 3, 6, 4, 5, 5, 8, "Elven Wizard", 6, 3, 3, 2, armyNumber));
        }
    }
}
