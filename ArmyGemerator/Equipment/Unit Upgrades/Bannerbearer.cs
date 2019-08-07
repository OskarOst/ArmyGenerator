using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class BannerBearer : UnitUpgrades
    {
        public BannerBearer()
        {
            SetStats(5, "Whenever you remove a Weariness counter, remove an additional counter", "Banner", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
