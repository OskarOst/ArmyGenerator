using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class Barbarians : BaseArmy
    {
        public Barbarians() : base()
        {
            armyNumber = 15;
            name = "Tribals";
            soldiers.Add(new BaseSoldiers(3, 4, 5, 6, 4, 6, 4, 6, "Tribal Brave", armyNumber));
            soldiers.Add(new BaseSoldiers(5, 4, 4, 6, 4, 5, 4, 6, "Tribal Warrior", "Bravery", armyNumber));
            soldiers.Add(new BaseSoldiers(7, 3, 4, 6, 3, 5, 4, 6, "Tribal Elder", "Bravery", armyNumber));
            soldiers.Add(new Artilleryman(5, 4, 4, 6, 4, 5, 4, 6, "Tribal Artilleryman", "Bravery", armyNumber));
            soldiers.Add(new BaseHero(30, 3, 3, 6, 3, 4, 4, 6, "Tribal Chief", 3, 4, armyNumber));
            soldiers.Add(new BaseHero(55, 4, 4, 6, 4, 6, 4, 6, "Tribal Shaman", "Magic Bolt", 6, 2, 2, 3, armyNumber));
        }
    }
}
