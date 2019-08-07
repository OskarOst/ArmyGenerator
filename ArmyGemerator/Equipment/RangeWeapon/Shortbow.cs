using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Shortbow : RangeWeapon
    {
        public Shortbow()
        {
            SetStats(2, "Range 9/18, fast volleys, arrow shower, mtd. move & shoot", "Shortbow", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
