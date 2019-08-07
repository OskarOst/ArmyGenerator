using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Zombify : Veteran
    {
        public Zombify()
        {
            SetStats(-2, "The unit is zombified. It gains the Undead rule, -2 Discipline +1 defence, a Shoot value of ' - ', can only move at halfspeed and may not use any weapons or armour. If at 16 unit strength, this unit only counts as a solid unit if Undead are the parent army. May not be purchased to a unit that already has the Undead rule", "Zombiefied", 1, 0, -2, -100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
