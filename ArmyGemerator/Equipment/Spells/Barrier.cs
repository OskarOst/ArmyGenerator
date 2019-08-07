using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Barrier : SpellsClass
    {
        public Barrier()
        {
            SetText("Barrier", "This is a preemptive spell. When cast, the next time one of your units are attacked, within the line of sight of the caster, by a ranged weapon, you can activate the barrier, giving it +2 defence until the next round. For every point of mana you use for the spell, the barrier gives +1 defence, to a maximum of +4.");
        }
    }
}
