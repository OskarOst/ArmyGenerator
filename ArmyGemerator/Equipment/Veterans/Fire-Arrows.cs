using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Fire_Arrows : Veteran
    {
        public Fire_Arrows()
        {
            SetStats(1, "Used with a unit armed with Shortbows or Longbows. The attacks count as fire-based.", "Fire Arrows", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
