using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class GreatWarrior : HeroTraits
    {
        public GreatWarrior()
        {
            SetStats(20, "Mighty (Very Mighty if already Mighty), Tough (+1)", "Great warrior", 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
