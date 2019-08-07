using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class Orc : BaseArmy
    {
        public Orc() : base()
        {
            armyNumber = 13;
            name = "Orcs";
            soldiers.Add(new BaseSoldiers(3, 4, 5, 5, 5, 6, 4, 6, "Orc Grunt", armyNumber));
            soldiers.Add(new BaseSoldiers(5, 4, 5, 5, 4, 5, 4, 6, "Orc Warrior", armyNumber));
            soldiers.Add(new BaseSoldiers(9, 3, 4, 5, 3, 5, 4, 6, "Orc Veteran", "Bravery", armyNumber));
            soldiers.Add(new Artilleryman(5, 4, 5, 5, 4, 5, 4, 6, "Artilleryorc", armyNumber));
            soldiers.Add(new BaseHero(30, 3, 4, 5, 3, 4, 4, 6, "Orc Chief", 3, 4, armyNumber));
            soldiers.Add(new BaseHero(50, 4, 4, 5, 4, 6, 4, 6, "Orc Sorceror", 6, 2, 2, 2, armyNumber));
        }
    }
}
