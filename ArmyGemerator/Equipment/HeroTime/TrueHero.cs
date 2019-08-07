using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class TrueHero : HeroTraits
    {
        public TrueHero()
        {
            SetStats(20, "Hero (+4)", "True Hero", 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
