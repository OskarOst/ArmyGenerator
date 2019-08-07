using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class InspiringLeader : HeroTraits
    {
        public InspiringLeader()
        {
            SetStats(20, "Leader (+2)", "Inspiring leader", 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
