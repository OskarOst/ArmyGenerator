using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Lance : MeleeWeapons
    {
        public Lance()
        {
            SetStats(2, "+2 to fight and -1 to enemy defence from armament when charging from long distance, +1 fight if charging from short distance. Bonus only lasts the fight round on the charge. ", "Lance", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
