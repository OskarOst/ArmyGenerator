using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Muscicians : UnitUpgrades
    {
        public Muscicians()
        {
            SetStats(5, "Ignore any Weariness counters above 1 when attempting to rally", "Muscicians", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
