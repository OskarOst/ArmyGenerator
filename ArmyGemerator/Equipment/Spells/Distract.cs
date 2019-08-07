using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Distract : SpellsClass
    {
        public Distract()
        {
            SetText("Distract", "Causes confusion and distress amongst an enemy unit. The unit targeted must take a Discipline check or add one Weariness counter and lose their formation. For every point of mana you use for the spell, the unit has -1 Discipline for the test and gains an additional Weariness counter. ");
        }
    }
}
