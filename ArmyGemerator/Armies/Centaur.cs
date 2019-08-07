using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class Centaur : BaseArmy
    {
        public Centaur() : base()
        {
            armyNumber = 1;
            name = "Centaurs";
            soldiers.Add(new CentaurSoldier(8, 5, 4, 6, 4, 6, 8, 16, "Centaur Brave", 1, 0, 2, armyNumber));
            soldiers.Add(new CentaurSoldier(10, 4, 4, 6, 4, 5, 8, 16, "Centaur Warrior", 1, 0, 2, armyNumber));
            soldiers.Add(new CentaurSoldier(14, 3, 4, 6, 4, 4, 8, 12, "Centaur Bull", "Powerful Charge", 1, 0, 2, armyNumber));
            soldiers.Add(new CentaurSoldier(13, 4, 3, 6, 4, 5, 8, 16, "Centaur Outrider", 1, 0, 2, armyNumber));
            soldiers.Add(new CentaurSoldier(15, 3, 4, 6, 3, 4, 8, 16, "Centaur Elder", 1, 0, 2, armyNumber));
            soldiers.Add(new CentaurHero(35, 3, 3, 6, 3, 4, 8, 16, "Centaur Chief", "",  0, 0, 1, 0, 2, 3, 3, armyNumber));
            soldiers.Add(new CentaurHero(55, 4, 4, 6, 4, 5, 8, 16, "Centaur Mystic", "", 6, 2, 1, 0, 2, 2, 2, armyNumber));
        }
    }
}
