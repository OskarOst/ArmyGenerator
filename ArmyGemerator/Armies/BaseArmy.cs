using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class BaseArmy
    {
        public List<BaseUnit> soldiers;
        public int armyNumber;
        public string name;
        public BaseArmy()
        {
            soldiers = new List<BaseUnit>();
            name = "dickbutts";
        }
        public string Name()
        {
            return name;
        }
        public BaseUnit ChosenSoldier(int chosen)
        {
            return soldiers[chosen].Clone();
        }
        public int SizeOfArmy()
        {
            return soldiers.Count;
        }
    }
}
