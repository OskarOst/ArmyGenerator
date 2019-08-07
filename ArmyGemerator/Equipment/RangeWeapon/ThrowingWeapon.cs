using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class ThrowingWeapon : RangeWeapon
    {
        public ThrowingWeapon()
        {
            SetStats(1, "range 6/6, move & shoot", "Throwing Weapon", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
