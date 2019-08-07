using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class HeavyCrossbow : RangeWeapon
    {
        public HeavyCrossbow()
        {
            SetStats(5, "Range 15/30, +1 shoot, 1 to enemy defence", "Heavy Crossbow", 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
