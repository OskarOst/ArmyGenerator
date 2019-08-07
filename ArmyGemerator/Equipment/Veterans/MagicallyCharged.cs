using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class MagicallyCharged : Veteran
    {
        public MagicallyCharged()
        {
            SetStats(1, "Enchants a unit's weapons with magic energy. All melee attacks from this unit counts as Magic Attacks ", "Magically Charged", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
