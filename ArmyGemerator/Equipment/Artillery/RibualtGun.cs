using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class RibaultGun : Artillery
    {
        public RibaultGun()
        {
            SetStats(50, "Range 12/24, -3 to enemy defence, Multiple barrels (8), slow reload, crew 3- 6", "Ribault Gun", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
