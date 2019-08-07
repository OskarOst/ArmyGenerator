using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Motivate : SpellsClass
    {
        public Motivate()
        {
            SetText("Motivate", "Gives a unit +2 fight during a single combat phase. For every point of mana you use, the fight bonus increase by +1.");
        }
    }
}
