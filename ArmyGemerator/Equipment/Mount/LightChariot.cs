using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class LightChariot : Mount
    {
        public LightChariot()
        {
            SetStats(14, "Increases movement to  8/16, Large Prescence (2), Skirmisher, Hit & Run, Chariot, Tough (1)", "Light Chariot", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 16, 1, 0, 3);
        }
    }
}
