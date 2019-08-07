using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class WarWagon : FieldFortification
    {
        public WarWagon()
        {
            SetStats(20, "Construct, Archer platform (6), Structure (2), Fire Weakness", "War Wagon", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6);
        }
    }
}
