using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Possessed : Veteran
    {
        public Possessed()
        {
            SetStats(3, "Gain Demonic rule and -1 Discipline. This may not be purchased to a unit that already has the Demonic rule.", "Possesed", 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
