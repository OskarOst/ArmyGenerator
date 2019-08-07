using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Feet : Mount
    {
        public Feet()
        {
            SetStats(0, "", "Feet", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
        public override bool WriteAsEquipment()
        {
            return false;
        }
    }
}
