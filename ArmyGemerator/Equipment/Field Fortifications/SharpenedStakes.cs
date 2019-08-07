using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class SharpenedStakes : FieldFortification
    {
        public SharpenedStakes()
        {
            SetStats(1, "If charged, the charging side loses any bonus they would gain from charging. The stakes cannot be moved, and a unit moving from them moves at half-speed.", "Sharpened Stakes", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
