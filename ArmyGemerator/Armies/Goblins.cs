using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class Goblins : BaseArmy
    {
        public Goblins() : base()
        {
            armyNumber = 7;
            name = "Goblins";
            soldiers.Add(new BaseSoldiers(2, 5, 4, 6, 6, 6, 4, 7, "Goblin Grunt", armyNumber));
            soldiers.Add(new BaseSoldiers(4, 5, 4, 6, 5, 5, 4, 7, "Goblin Warrior", armyNumber));
            soldiers.Add(new Artilleryman(4, 5, 4, 6, 5, 5, 4, 7, "Artillerygoblin", armyNumber));
            soldiers.Add(new BaseHero(20, 4, 3, 6, 4, 5, 4, 7, "Goblin Cheif", 2, 2, armyNumber));
            soldiers.Add(new BaseHero(35, 5, 4, 6, 5, 6, 4, 7, "Goblin Sorcerer", 6, 2, 1, 1, armyNumber));
        }
    }
}
