using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    class ItemAdder
    {
        public bool Test(Equipment newEquipment, List<Equipment> oldEquipment, BaseUnit soldiertype)
        {
            for (int i = 0; i < oldEquipment.Count; i++)
            {
                //If weapons is for foot only
                if ((newEquipment is Polearm || newEquipment is Pavise || newEquipment is Pike || newEquipment is Spear || newEquipment is DualWieldedWeapon) && !(oldEquipment[5] is Feet))
                {
                    return false;
                }
                // if weapons are for mounted only.
                else if ((newEquipment is Lance) && (oldEquipment[5] is Feet))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
