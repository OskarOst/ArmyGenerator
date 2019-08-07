using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class GoodOldFists : RangeWeapon
    {
        public GoodOldFists()
        {
            SetStats(0,"","Harsh Language",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);
        }
        public override bool WriteAsEquipment()
        {
            return false;
        }
    }
}
