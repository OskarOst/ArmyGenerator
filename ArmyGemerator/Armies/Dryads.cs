using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class Dryads : BaseArmy
    {
        public Dryads() : base()
        {
            armyNumber = 4;
            name = "Dryads";
            soldiers.Add(new DryadSoldier(6,4,4,5,4,4,4,6, "Dryad Sapling", armyNumber));
            soldiers.Add(new DryadSoldier(8, 3, 4, 5, 3, 4, 4, 6, "Dryad Guardian", "Magical Attacks", armyNumber));
            soldiers.Add(new DryadSoldier(11, 3, 3, 4, 3, 3, 4, 6, "Dryad Sentinel", "Magical Attacks", armyNumber));
            soldiers.Add(new DryadHero(60, 2, 2, 4, 2, 3, 4, 6, "Dryad Warden", "Magical Attacks", 3, 1, 3, 4, armyNumber));
        }
    }
}
