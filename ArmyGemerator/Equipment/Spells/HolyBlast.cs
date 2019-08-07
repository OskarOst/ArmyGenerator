using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class HolyBlast : SpellsClass
    {
        public HolyBlast()
        {
            SetText("Holy Blast", "Fires a blast of magical energy at an enemy. For every point of Mana you use for the spell, it causes another hit at the enemy. The blast hits automatically and is Mighty. The attack has a range of 24 inches. If targeted at an Undead or Demonic unit, it inflicts another hit and counts as a fire attack. The additonal hit is Mighty. ");
        }
    }
}
