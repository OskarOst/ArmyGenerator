using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Diciples : Veteran
    {
        public Diciples()
        {
            SetStats(5, "The unit gains the Magic Bolt rule. For every 5 soldiers in the unit, you gain +1 mana to your mana pool", "Disciples", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
