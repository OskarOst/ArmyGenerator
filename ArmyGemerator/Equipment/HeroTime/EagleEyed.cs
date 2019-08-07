using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class EagleEyed : HeroTraits
    {
        public EagleEyed()
        {
            SetStats(20, "Mighty added for any ranged weapon, Hero (+2)", "Eagle-Eyed", 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
