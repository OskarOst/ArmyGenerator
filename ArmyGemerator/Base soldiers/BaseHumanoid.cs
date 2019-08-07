using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
namespace ArmyGenerator
{
    [Serializable]
    class BaseHumanoid:BaseFightingMen
    {
        private Armour armour;
        private Mount mount;
        public BaseHumanoid(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, army)
        {
            AddEquipment();
        }
        public BaseHumanoid(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, rules, army)
        {
            AddEquipment();
        }
        public BaseHumanoid(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, int though, int mighty, int size, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, though, mighty, size, army)
        {
            AddEquipment();
        }
        public BaseHumanoid(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int though, int mighty, int size, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, rules, though, mighty, size, army)
        {
            AddEquipment();
        }
        public BaseHumanoid(BaseHumanoid input) : base(input)
        {
            AddEquipment(); 
        }
        public override BaseUnit Clone()
        {
            return new BaseHumanoid(this);
        }
        public override bool CanAddItem(Equipment equipment)
        {
            if (equipment is Armour || equipment is Mount)
            {
                return true;
            }
            return base.CanAddItem(equipment);
        }
        public override void ResetEquipment()
        {
            AddEquipment();
            base.ResetEquipment();
        }
        public override void EquipUnit(Equipment input)
        {
            if (input is Armour)
            {
                armour = input as Armour;
            }
            else if (input is Mount)
            {
                mount = input as Mount;
            }
            else
            {
                base.EquipUnit(input);
            }
        }
        public override List<Equipment> GetEquipment()
        {
            List<Equipment> output = base.GetEquipment();
            output.Add(armour);
            output.Add(mount);
            return output;
        }
        public override int GetCost()
        {
            if (mount.ArcherPlatform())
            {
                return base.GetCost() + armour.Cost();
            }
            else
            {
                return base.GetCost() + armour.Cost() + mount.Cost(); 
            }
        }
        private void AddEquipment()
        {
            armour = new UnArmoured();
            mount = new Feet();
        }
    }
}
