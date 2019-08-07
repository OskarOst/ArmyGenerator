using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class LightCatapult : Artillery
    {
        public LightCatapult()
        {
            SetStats(35, "Range 2/40, -3 to enemy defence, Mighty, Artillery, Wall wrecker, Crew: 2-4", "Light Catapult", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0);
        }
    }
}
