using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class UnArmoured : Armour
    {
        public UnArmoured()
        {
            SetStats(0, "", "Unarmoured", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
        public override bool WriteAsEquipment()
        {
            return false;
        }
    }
}
