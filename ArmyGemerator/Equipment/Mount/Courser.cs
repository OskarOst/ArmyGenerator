using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Courser : Mount
    {
        public Courser()
        {
            SetStats(5, "Increases movement to  8/16, Large Prescence (2), Hit & Run", "Courser", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 8, 16, 0, 0, 0);
        }
    }
}
