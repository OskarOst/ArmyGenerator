using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class LightCrossbow : RangeWeapon
    {
        public LightCrossbow()
        {
            SetStats(3, "Range 10/20, +1 shoot, mtd. move & shoot", "Light Crossbow", 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
