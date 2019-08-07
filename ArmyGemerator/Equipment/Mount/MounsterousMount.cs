using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class MonsterousMount : Mount
    {
        public MonsterousMount()
        {
            SetStats(15, "Increases movement to  6/10", "Monsterous Mount", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 6, 10, 2, 1, 0);
        }
    }
}
