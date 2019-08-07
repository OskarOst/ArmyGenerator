using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Cannon : Artillery
    {
        public Cannon()
        {
            SetStats(70, "Range 30/60, -4 to enemy dafence, Very Mighty, Crew 2-6", "Cannon", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0);
        }
    }
}
