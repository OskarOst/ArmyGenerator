using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class SavageFighters : Veteran
    {
        public SavageFighters()
        {
            SetStats(1, "The unit cannot engage in formations but will not add any Weariness counter for a failed Discipline test as a result of failing a fight.", "Savage Fighters", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
