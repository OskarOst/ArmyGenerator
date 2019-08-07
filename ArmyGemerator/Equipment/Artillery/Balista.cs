using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Balista : Artillery
    {
        public Balista()
        {
            SetStats(20, "Range 20/40, -3 to enemy defence, mighty, Crew: 2-4", "Balista", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0);
        }
    }
}
