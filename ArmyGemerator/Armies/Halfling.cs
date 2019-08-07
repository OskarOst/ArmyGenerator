using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class Halfling : BaseArmy
    {
        public Halfling() : base()
        {
            armyNumber = 8;
            name = "Haflings";
            soldiers.Add(new BaseSoldiers(3, 5, 4, 6, 3, 6, 3, 5, "Hafling Militia", armyNumber));
            soldiers.Add(new BaseSoldiers(4, 5, 4, 6, 3, 5, 3, 5, "Hafling-at-arms", armyNumber));
            soldiers.Add(new BaseSoldiers(6, 4, 4, 6, 3, 4, 3, 5, "Hafling Veterans", armyNumber));
            soldiers.Add(new Artilleryman(4, 5, 4, 6, 3, 5, 3, 5, "Artilleryhafling", armyNumber));
            soldiers.Add(new BaseHero(25, 4, 3, 6, 3, 4, 3, 5, "Havling Captain", 2, 3, armyNumber));
            soldiers.Add(new BaseHero(40, 5, 4, 6, 3, 5, 3, 5, "Halfling Wizard", 6, 2, 1, 2, armyNumber));
        }
    }
}
