using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class Ratmen : BaseArmy
    {
        public Ratmen() : base()
        {
            armyNumber = 14;
            name = "Ratmen";
            soldiers.Add(new BaseSoldiers(2, 5, 5, 6, 6, 6, 5, 8, "Ratfolk Grunt", armyNumber));
            soldiers.Add(new BaseSoldiers(4, 4, 4, 6, 5, 5, 5, 8, "Ratfolk Warrior", armyNumber));
            soldiers.Add(new BaseSoldiers(6, 3, 4, 6, 5, 4, 5, 8, "Ratfolk Veteran", armyNumber));
            soldiers.Add(new Artilleryman(4, 4, 4, 6, 5, 5, 5, 8, "Artilleryrat", armyNumber));
            soldiers.Add(new BaseHero(20, 3, 3, 6, 4, 4, 5, 8, "Ratfolk Chief", 3, 1, armyNumber));
            soldiers.Add(new BaseHero(40, 4, 4, 6, 5, 5, 5, 8, "Ratfolk Sorceror", 6, 2, 2, 1, armyNumber));
        }
    }
}
