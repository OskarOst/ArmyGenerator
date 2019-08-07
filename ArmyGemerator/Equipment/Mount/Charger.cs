using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Charger : Mount
    {
        public Charger()
        {
            SetStats(5, "Increases movement to  8/12, Large Prescence (2), Hit & Run, Powerful charge", "Charger", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 8, 12, 0, 0, 0);
        }
    }
}
