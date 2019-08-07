using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class Human : BaseArmy
    {
        public Human() : base()
        {
            armyNumber = 10;
            name = "Humans";
            soldiers.Add(new BaseSoldiers(3, 5, 4, 6, 5, 5, 4, 6, "Human Militia", armyNumber));
            soldiers.Add(new BaseSoldiers(5, 4, 4, 6, 4, 4, 4, 6, "Human Man-at-arm", armyNumber));
            soldiers.Add(new BaseSoldiers(8, 3, 4, 6, 4, 3, 4, 6, "Human Veteran", armyNumber));
            soldiers.Add(new BaseSoldiers(8, 3, 4, 6, 3, 4, 4, 6, "Human Knight", armyNumber));
            soldiers.Add(new Artilleryman(5, 4, 4, 6, 4, 4, 4, 6, "Human Artilleryman", armyNumber));
            soldiers.Add(new BaseHero(30, 3, 3, 6, 3, 3, 4, 6, "Human Captain", 3, 3, armyNumber));
            soldiers.Add(new BaseHero(50, 4, 4, 6, 4, 5, 4, 6, "Human Wizard", 6, 2, 2, 2, armyNumber));
        }
    }
}
