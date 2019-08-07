using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class CoveringPlateHorseArmour : Armour
    {
        public CoveringPlateHorseArmour()
        {
            SetStats(10, "+3 defence, -2 max movement (Coursers & flyers only)", "Covering Plate armour", 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
