using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class Creatures : BaseArmy
    {
        public Creatures() : base()
        {
            name = "Creatures";
            armyNumber = 2;
            soldiers.Add(new BaseSoldiers(40, 4, 0, 4, 4, 6, 4, 7, "Troll", "Regenerative", 2, 1, 4, armyNumber));
            soldiers.Add(new Beast(40, 3, 0, 4, 2, 4, 5, 8, "Treeman", "Fire weakness, Entangle, Beast", 3, 1, 4, armyNumber));
            soldiers.Add(new Beast(130, 2, 0, 4, 2, 4, 4, 6, "Ancient Treeman", "Attacks have -2 to enemy defence, Fire weakness, Entangle, Frightening, Fearsome, Loner", 2 ,5, 16, armyNumber));
            soldiers.Add(new Beast(6, 4, 0, 6, 5, 6, 6, 10, "Warhound", "Skirmisher", armyNumber));
            soldiers.Add(new Beast(80, 4, 0, 4, 3, 6, 6, 10, "Warbeast", "Attacks have -2 to enemy defence, thick skin, Powerful Charge, Fearsome, Archer Platform (6)", 4, 2, 12, armyNumber));
            soldiers.Add(new BaseSoldiers(130, 3, 4, 4, 4, 6, 5, 8, "Giant", "Attacks have -3 to enemy defence, Thick Skin, Bravery, Frightening, Powerful Charge, Gigantic, Fearsome, Loner", 5, 2, 16, armyNumber));
            soldiers.Add(new Beast(190, 2, 0, 4, 2, 5, 5, 8, "Hydra", "Attacks have - 3 to enemy defence, Thick Skin, Bravery, Frightening, Regenerative, Powerful Charge, Beast, Fearsome, Loner, Rideable", 5, 2, 16, armyNumber));
            soldiers.Add(new Beast(170, 2, 0, 4, 4, 4, 8, 14, "Griffon", "Attacks have - 3 to enemy defence, Thick Skin, Fire Weakness,  Frightening, Flying, Powerful Charge, Bravery, Loner", 4, 2, 16, armyNumber));
            soldiers.Add(new Beast(205, 2, 4, 4, 4, 4, 8, 12, "Manticore", "Attacks have -3 to enemy defence, Thick Skin, Frightening, Flying, Powerful Charge, Bravery, Loner, Rideable, Barb Attack", 4, 2, 16, armyNumber));
            soldiers.Add(new Beast(275, 2, 3, 3, 2, 4, 8, 12, "Dragon", "Flying, Thick Skin, Fire breath, Attacks have -3 to enemy defence, Bravery, Frightening, Powerful Charge, Beast, Fearsome, Loner, Rideable", 5, 2, 16, armyNumber));
            soldiers.Add(new Beast(40, 4, 0, 3, 2, 5, 4, 6, "Earth Elemental", "Thick Skin", 3, 1, 4, armyNumber));
            soldiers.Add(new Beast(40, 4, 4, 5, 3, 6, 6, 10, "Fire Elemental", "Fire Breath, Fire Attacks, Magic Attacks", 2, 1, 4, armyNumber));
            soldiers.Add(new Beast(40, 4, 0, 4, 3, 6, 4, 6, "Water Elemental", "Regeneration, Magic Attacks", 2, 1, 4, armyNumber));
            soldiers.Add(new Beast(45, 4, 3, 6, 3, 6, 8, 12, "Air Elemental", "Flying, Magic Bolt (Mighty), Magic Attacks", 2, 1, 4, armyNumber));
        }
    }
}
