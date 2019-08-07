using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class Ogre : BaseArmy
    {
        public Ogre() : base()
        {
            armyNumber = 12;
            name = "Ogres";
            soldiers.Add(new BaseSoldiers(15, 5, 5, 4, 5, 6, 4, 8, "Ogre Thug", "Commonplace", 1, 1, 4, armyNumber));
            soldiers.Add(new BaseSoldiers(20, 4, 4, 4, 4, 6, 4, 8, "Ogre Warrior", "Commonplace", 1, 1, 4, armyNumber));
            soldiers.Add(new BaseSoldiers(31, 4, 4, 4, 3, 5, 4, 8, "Ogre Veteran", "Commonplace", 1, 1, 4, armyNumber));
            soldiers.Add(new Artilleryman(20, 4, 4, 4, 4, 6, 4, 8, "Ogre Warrior", "Commonplace", 1, 1, 4, armyNumber));
            soldiers.Add(new BaseHero(55, 3, 4, 4, 3, 4, 4, 8, "Ogre Captain", "", 0, 0, 2, 1, 4, 1, 2, armyNumber));
            soldiers.Add(new BaseHero(70, 4, 4, 4, 4, 6, 4, 8, "Ogre Magi", "", 6, 2, 2, 1, 4, 1, 2, armyNumber));
        }
    }
}
