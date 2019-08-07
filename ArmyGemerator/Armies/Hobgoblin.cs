using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class Hobgoblin : BaseArmy
    {
        public Hobgoblin() : base()
        {
            armyNumber = 9;
            name = "Hobgoblin";
            soldiers.Add(new BaseSoldiers(3, 4, 5, 6, 5, 5, 4, 6, "Hobgoblin Grunt", armyNumber));
            soldiers.Add(new BaseSoldiers(5, 4, 4, 6, 5, 4, 4, 6, "Hobgoblin Warrior", armyNumber));
            soldiers.Add(new BaseSoldiers(7, 3, 4, 6, 4, 4, 4, 6, "Hobgoblin Veteran", armyNumber));
            soldiers.Add(new Artilleryman(5, 4, 4, 6, 5, 4, 4, 6, "Artilleryhobgoblin", armyNumber));
            soldiers.Add(new BaseHero(25, 3, 3, 6, 4, 3, 4, 6, "Hobgoblin Captain", 3, 2, armyNumber));
            soldiers.Add(new BaseHero(45, 4, 5, 6, 5, 5, 4, 6, "Hobgoblin Sorcerer", 6, 2, 2, 2, armyNumber));
        }
    }
}
