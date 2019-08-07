using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class DualWieldedWeapon : MeleeWeapons
    {
        public DualWieldedWeapon()
        {
            SetStats(1, "+1 to fight, dual handed", "Dual Weapons", 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
