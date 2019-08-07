using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class ArmyStandard : HeroTraits
    {
        public ArmyStandard()
        {
            SetStats(20, "Every friendly unit within 6 inches of this character gains +1 to win a fight and adds 2 Morale to the army, You can only have one Army standard per Army.", "Army Standard", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
