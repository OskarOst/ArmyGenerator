using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class FireBlast : SpellsClass
    {
        public FireBlast()
        {
            SetText("Fire Blast", "Fires a blast of magical energy at an enemy. For every point of Mana you use for the spell, it causes another hit at the enemy. The blast hits automatically and is Mighty. The attack has a range of 24 inches. If the unit takes casualties, it takes another hit next round. This counts as a fire attack, and is Mighty.");
        }
    }
}
