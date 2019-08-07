using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Weaken : SpellsClass
    {
        public Weaken()
        {
            SetText("Weaken", "Temporarily strips the defence from an enemy unit. Gives -1 defence to an enemy unit for the active round. For every point of mana you use, the defence is decreased by an additional -1. This spell has a range of 12 inches.");
        }
    }
}
