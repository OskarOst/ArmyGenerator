using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Beast:BaseUnit
    {
        public Beast(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, int army) :base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, "Beast", army)
        {
        }
        public Beast(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, "Beast, "+ rules, army)
        {
        }
        public Beast(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int though, int mighty, int size, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, "Beast, " + rules, though, mighty, size, army)
        {
        }
        public Beast(Beast input):base(input)
        {
        }
        public override BaseUnit Clone()
        {
            return new Beast(this);
        }
    }
}
