using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class HeavyHorseArmour : Armour
    {
        public HeavyHorseArmour()
        {
            SetStats(5, "+2 defence, -2 max movement (coursers & flyers only)", "Heavy Horse Armour", 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
