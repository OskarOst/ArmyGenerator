using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Inspire : SpellsClass
    {
        public Inspire()
        {
            SetText("Inspire", "Removes a Routed status or one Weariness counter of one friendly unit. If cast on a character, it adds one Hero (*) point. For every point of mana you use for the spell, it removes an  additional Routed status or Weariness counter  on the same or any other unit, or adds another Hero (*) point.");
        }
    }
}
