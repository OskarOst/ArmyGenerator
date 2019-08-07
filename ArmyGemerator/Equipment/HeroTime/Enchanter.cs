using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Enchanter : HeroTraits
    {
        public Enchanter()
        {
            SetStats(20, "For Counterspelling, the wizard gains +1 to the dice roll, and +3 Mana", "Enchanter", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
