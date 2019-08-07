using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class ArtilleryEngineer : UnitUpgrades
    {
        public ArtilleryEngineer()
        {
            SetStats(20, "Re-roll any failed Shoot dice or dice to decide casualty amount from Mighty of Very Might hits", "Siege Engineer", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
