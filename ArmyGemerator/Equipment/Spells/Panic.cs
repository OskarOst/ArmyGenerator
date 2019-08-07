using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Panic : SpellsClass
    {
        public Panic()
        {
            SetText("Panic", "Causes panic and terror amongst an enemy unit. The unit targeted must take a Courage check or add one Weariness counter and lose their formation. For every point of mana you use for the spell, the unit has -1 Courage for the test and gains an additional Weariness counter.");
        }
    }
}
