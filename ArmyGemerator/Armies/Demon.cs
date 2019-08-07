using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class Demon : BaseArmy
    {
        public Demon() : base()
        {
            armyNumber = 3;
            name = "Demons";
            soldiers.Add(new BaseSoldiers(3,5,5,6,5,5,5,8, "Demon Imp", "Demonic", armyNumber));
            soldiers.Add(new Beast(10, 3, -10, 6, 5, 5, 5, 8, "Demon Hound", "Demonic, Skrimisher", armyNumber));
            soldiers.Add(new BaseSoldiers(6, 4, 4, 5, 4, 5, 4, 6, "Demon Minion", "Demonic", armyNumber));
            soldiers.Add(new BaseSoldiers(10, 3, 4, 5, 3, 4, 4, 5, "Rage Demon", "Demonic, Bravery", armyNumber));
            soldiers.Add(new BaseSoldiers(8, 4, 3, 6, 4, 4, 5, 8, "Desire Demon", "Demonic, Bravery", armyNumber));
            soldiers.Add(new BaseSoldiers(7, 4, 4, 4, 4, 5, 3, 5, "Sloth Demon", "Demonic, Bravery", armyNumber));
            soldiers.Add(new BaseSoldiers(11, 4, 3, 6, 4, 4, 4, 6, "Arcane Demon", "Demonic, Bravery, Magic Bolt", armyNumber));
            soldiers.Add(new BaseSoldiers(35, 4, 4, 4, 4, 5, 4, 6, "Demon Spawn", "Demonic, Frightening", 2, 1, 4, armyNumber));
            soldiers.Add(new Artilleryman(6, 4, 4, 5, 4, 5, 4, 6, "Artillerydemon", "Demonic", armyNumber));
            soldiers.Add(new BaseHero(95, 2, 2, 4, 4, 4, 5, 8, "Demon Lord","Magic Bolt, Demonic, Frightening, Fearsome", 3, 1, 3, 1, 4, 3, 2, armyNumber));
            soldiers.Add(new BaseHero(35, 3, 4, 5, 3, 3, 4, 6, "Demon Warrior Champion", "Demonic", 2, 3, armyNumber));
            soldiers.Add(new BaseHero(55, 4, 3, 6, 4, 4, 5, 8, "Demon Arcane Champion", "Magic Bolt, Demonic", 6, 3, 1, 0, 1, 2, 2, armyNumber));
        }
    }
}
