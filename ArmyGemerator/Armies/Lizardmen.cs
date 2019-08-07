using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class Lizardmen : BaseArmy
    {
        public Lizardmen() : base()
        {
            armyNumber = 11;
            name = "LizardFolks";
            soldiers.Add(new BaseSoldiers(4, 5, 4, 6, 4, 6, 6, 8, "Lizardling", armyNumber));
            soldiers.Add(new BaseSoldiers(6, 4, 4, 5, 4, 5, 4, 6, "Lizard Warrior", armyNumber));
            soldiers.Add(new BaseSoldiers(10, 3, 4, 5, 3, 4, 4, 6, "Lizard Oldbloods", armyNumber));
            soldiers.Add(new BaseSoldiers(30, 4, 4, 4, 4, 5, 4, 8, "Lizard Brute", "Powerful Charge", 2, 1, 4, armyNumber));
            soldiers.Add(new Artilleryman(6, 4, 4, 5, 4, 5, 4, 6, "Artillerylizard", armyNumber));
            soldiers.Add(new BaseHero(40, 3, 4, 5, 3, 4, 4, 6, "Lizard Chieftain", "", 0, 0, 1, 1, 1, 2, 4, armyNumber));
            soldiers.Add(new BaseHero(25, 4, 3, 6, 3, 4, 6, 8, "Lizardling Chieftain", 2, 3, armyNumber));
            soldiers.Add(new BaseHero(40, 5, 4, 6, 4, 6, 6, 8, "LizardlingSorcerer", 6, 2, 2, 2, armyNumber));
        }
    }
}
