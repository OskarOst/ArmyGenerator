using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Shield : MeleeWeapons
    {
        public Shield()
        {
            SetStats(1, "Shieldwall, +1 defence from ranged attacks, +1 defence from all attacks if mounted", "Shield", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
