﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class GenericVeteran : Veteran
    {
        public GenericVeteran()
        {
            SetStats(0, "", "generic soldiers", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
        public override bool WriteAsEquipment()
        {
            return false;
        }
    }
}
