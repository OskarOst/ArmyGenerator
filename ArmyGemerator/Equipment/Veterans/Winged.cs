using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Winged : Veteran
    {
        public Winged()
        {
            SetStats(8, "Used with a unit on foot. This unit is winged and can soar in the air. The unit gains +2 to max speed and the Flying rule.", "Winged", 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
