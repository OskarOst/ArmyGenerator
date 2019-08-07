using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class HeavyCatapult : Artillery
    {
        public HeavyCatapult()
        {
            SetStats(45, "Range 30/60, -3 to enemy defence, Mighty, Artillery, Wall wercker, Crew: 3- 6", "Heavy Catapult", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0);
        }
    }
}
