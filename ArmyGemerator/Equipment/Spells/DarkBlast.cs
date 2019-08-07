﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class DarkBlast : SpellsClass
    {
        public DarkBlast()
        {
            SetText("Dark Blast", "Fires a blast of magical energy at an enemy. For every point of Mana you use for the spell, it causes another hit at the enemy. The blast hits automatically and is Mighty. The attack has a range of 24 inches. The targeted unit must pass a courage test, or add one Weariness counter.");
        }
    }
}