using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace ArmyGenerator
{
    [Serializable]
    class BaseDryad:BaseFightingMen
    {
        private Mount mount;
        public BaseDryad(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, "Cannot wear armour", army)
        {
            mount = new Feet();
        }
        public BaseDryad(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, "Cannot wear armour, " + rules, army)
        {
            mount = new Feet();
        }
        public BaseDryad(BaseDryad input) : base(input)
        {
            mount = new Feet();
        }
        public override BaseUnit Clone()
        {
            return new BaseDryad(this); 
        }
        public override void EquipUnit(Equipment input)
        {
            if (input is Mount)
            {
                mount = input as Mount;
            }
            else
            {
                base.EquipUnit(input);
            }
        }
        public override bool CanAddItem(Equipment equipment)
        {
            if (equipment is Mount)
            {
                return true;
            }
            return base.CanAddItem(equipment);
        }
        public override void ResetEquipment()
        {
            mount = new Feet();
            base.ResetEquipment();
        }
        public override List<Equipment> GetEquipment()
        {
            List<Equipment> output = base.GetEquipment();
            output.Add(mount);
            return output;
        }
        public override int GetCost()
        {
            if (mount.ArcherPlatform())
            {
                return base.GetCost() + mount.Cost();
            }
            else
            {
                return base.GetCost();
            }
        }
    }
}
