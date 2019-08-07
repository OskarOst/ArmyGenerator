using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Commandos : Veteran
    {
        public Commandos()
        {
            SetStats(3, "Gain skirmish rule and the unit will not add any Weariness counter for a failed Discipline test as a result of failing a fight.", "Comandos", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
         }
    }
}
