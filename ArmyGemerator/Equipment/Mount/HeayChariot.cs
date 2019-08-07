using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class HeavyChariot : Mount
    {
        public HeavyChariot()
        {
            SetStats(13, "Increases movement to  8/12, Large Prescence (2), Powerful charge, Hit & Run, Chariot, Tough (1)", "heavy Chariot", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 12, 1, 0, 3);
        }
    }
}
