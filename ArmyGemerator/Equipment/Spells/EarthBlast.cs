using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class EarthBlast : SpellsClass
    {
        public EarthBlast()
        {
            SetText("Earth Blast", "Fires a blast of magical energy at an enemy. For every point of Mana you use for the spell, it causes another hit at the enemy. The blast hits automatically and is Mighty. The attack has a range of 24 inches. The spell does not require line of sight to cast. ");
        }
    }
}
