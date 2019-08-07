using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Healing : SpellsClass
    {
        public Healing()
        {
            SetText("Healing", "Heals wounded members of a unit. For every point of mana you use for the spell, it restores 1d3 casualties. This spell cannot bring a hero back. If used on a unit with Tough (*), it restores 1d3/2 casualties.");
        }
    }
}
