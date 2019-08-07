using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class GenericHero : HeroTraits
    {
        public GenericHero()
        {
            SetStats(0, "", "Generic Hero", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
        public override bool WriteAsEquipment()
        {
            return false;
        }
    }
}
