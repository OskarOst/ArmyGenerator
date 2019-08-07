using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class Beastmen : BaseArmy
    {
        public Beastmen() : base()
        {
            armyNumber = 0;
            name = "Beastmen";
            soldiers.Add(new BaseSoldiers(3,4,4,6,5,6,4,7, "Lesser Beastman", armyNumber));
            soldiers.Add(new BaseSoldiers(5, 4, 4, 5, 4, 6, 4, 7, "Beastman", armyNumber));
            soldiers.Add(new BaseSoldiers(8, 3, 4, 5, 4, 5, 4, 7, "Elder Beastman", armyNumber));
            soldiers.Add(new BaseSoldiers(29, 4, 4, 4, 4, 6, 4, 8, "Minotaur", "Powerful Charge", 2, 1, 3, armyNumber));
            soldiers.Add(new Artilleryman(5, 4, 4, 5, 4, 6, 4, 7, "Artillerybeast", armyNumber));
            soldiers.Add(new BaseHero(30, 3, 4, 5, 3, 5, 4, 7, "Beastman Chief", 2, 4, armyNumber));
            soldiers.Add(new BaseHero(45, 4, 4, 5, 4, 6, 4, 7, "Beastman Shaman", "Magic Bolt", 6, 2, 1, 3, armyNumber));
        }
    }
}
