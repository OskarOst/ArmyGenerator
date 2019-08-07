using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Spear : MeleeWeapons
    {
        public Spear()
        {
            SetStats(1, "Spear wall. +1 fight vs mounted", "Spear", 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);
        }
    }
}
