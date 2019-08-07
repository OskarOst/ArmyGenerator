using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Conjurer : HeroTraits
    {
        public Conjurer()
        {
            SetStats(20, "Gain one Spell and +3 Mana.", "Conjurer", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0);
        }
    }
}
