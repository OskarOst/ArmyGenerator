using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class Dragonslayer : HeroTraits
    {
        public Dragonslayer()
        {
            SetStats(20, "When attacking an enemy with Large Prescence (3) or higher, their tough (*) value is reduced by 2 against the Dragonslayers attacks, to a minimum of Tough (1)", "Dragonslayer", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
