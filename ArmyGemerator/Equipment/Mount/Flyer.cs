using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Flyer : Mount
    {
        public Flyer()
        {
            SetStats(12, "Increases movement to 8/16, Flying, Large Prescence (2), Hit & Run", "Flyer", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 8, 16, 0, 0, 0);
        }
    }
}
