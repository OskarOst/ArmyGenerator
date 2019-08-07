using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class DarkSummon : SpellsClass
    {
        public DarkSummon()
        {
            SetText("Dark Summon", "Summons a creature made from magical energy to the battlefield. The creature may be placed within 8 inches of the caster, and already counts as being activated. Should the caster use another spell after Summon, the creature will be instantly removed from the field. If spending two mana on the spell, the creature gains Mighty, and if three, Very Mighty. Depending on what type, the summon has different profiles. Profiles are found in the Creature army. ");
        }
    }
}
