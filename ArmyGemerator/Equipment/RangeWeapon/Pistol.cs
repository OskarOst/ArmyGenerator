using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Pistol : RangeWeapon
    {
        public Pistol()
        {
            SetStats(4, "Range 6/6, -3 to enemy Defence, move and shoot", "Pistol", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
