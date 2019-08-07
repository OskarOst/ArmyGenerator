using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class NumberHandler
    {
        public int Returnpoints(List<Equipment> thing, int cost)
        {
            int returnNumber = cost;
            int heroMultplyer = 0;
            int heroPoints = 0;
            for (int i = 0; i < thing.Count; i++)
            {
                if (i < 12)
                {
                    if (thing[i] != null && (i != 8 && i != 9 && i != 10 && i != 11))
                    {
                        if (thing[5] is HeavyChariot || thing[5] is LightChariot || thing[7] is WarWagon)
                        {
                        }
                        else
                            returnNumber += thing[i].Cost();
                    }
                }
                else if (i > 11 && !(thing[i] is GenericHero))
                {
                    heroMultplyer++;
                }
            }
            for (int i = 1; i <= heroMultplyer; i++)
            {
                heroPoints += 20 * i;
            }
            if(returnNumber < 2)
            {
                returnNumber = 2;
            }
            return returnNumber + heroPoints;
        }
        public int Returnpoints(int numberOfSoldiers, BaseUnit type)
        {
            return (type.GetCost() * numberOfSoldiers) + type.GetOneTimeCost() + type.GetArcherPlatformCost(numberOfSoldiers);
        }
    }
}
