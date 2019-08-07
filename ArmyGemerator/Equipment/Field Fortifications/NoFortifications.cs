using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class NoFortifications : FieldFortification
    {
        public NoFortifications()
        {
            SetStats(0, "", "No Fortifications", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
        public override bool WriteAsEquipment()
        {
            return false;
        }
    }
}
