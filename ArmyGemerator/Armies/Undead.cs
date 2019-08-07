using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class Undead : BaseArmy
    {
        public Undead() : base()
        {
            armyNumber = 16;
            name = "Undead";
            soldiers.Add(new BaseSoldiers(5, 4, 5, 6, 4, 5, 4, 6, "Skeleton Warrior", "Undead", armyNumber));
            soldiers.Add(new BaseSoldiers(8, 3, 4, 6, 3, 4, 4, 6, "Skeleton Knight", "Undead, Drilled", armyNumber));
            soldiers.Add(new BaseSoldiers(8, 3, 4, 5, 3, 3, 3, 5, "Embalmed Dead", "Undead FireWeakness", armyNumber));
            soldiers.Add(new BaseSoldiers(3, 4, -200, 5, 4, 6, 4, 4, "Walking Corpses", "Zombified", armyNumber ));
            soldiers.Add(new BaseSoldiers(10, 4, -200, 6, 6, 6, 6, 8, "Ghost", "Undead, Incoporeal, Cannot use formations", armyNumber));
            soldiers.Add(new BaseSoldiers(25, 4, 5, 4, 4, 5, 4, 8, "Skeletal Construct", "Undead", 2, 1, 4, armyNumber));
            soldiers.Add(new Artilleryman(8, 3, 4, 6, 3, 4, 4, 6, "Artilleryskeleton", "Undead, Drilled", armyNumber));
            soldiers.Add(new BaseHero(30, 3, 4, 6, 3, 4, 4, 6, "Skeleton Captain", "Undead", 3, 3, armyNumber));
            soldiers.Add(new BaseHero(50, 4, 5, 6, 4, 6, 4, 6, "Skeleton Magi", "Undead", 6, 2, 2, 2, armyNumber ));
            List<SpellsClass> spellList = new List<SpellsClass>();
            spellList.Add(new Healing());
            soldiers.Add(new BaseHero(70, 2, 3, 6, 2, 3, 5, 8, "Vampire", "Regenerative", 3, 1, 1, 1, 1, 4, 4, armyNumber, spellList));
        }
    }
}
