using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class FlameThrower : Artillery
    {
        public FlameThrower()
        {
            SetStats(20, "Fire Breath, Skirmisher, +1 shoot, can be targeted while in woods, crew 2-3", "Liquid Fire Cannon", 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0);
        }
    }
}
