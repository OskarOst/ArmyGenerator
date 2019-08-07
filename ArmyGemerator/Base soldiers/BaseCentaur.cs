using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class BaseCentaur:BaseFightingMen
    {
        private Armour armour;
        public BaseCentaur(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, "Centaur", army)
        {
            armour = new UnArmoured();
        }
        public BaseCentaur(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, "Centaur, " + rules, army)
        {
            armour = new UnArmoured();
        }
        public BaseCentaur(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, int though, int mighty, int size, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, "Centaur", though, mighty, size, army)
        {
            armour = new UnArmoured();
        }
        public BaseCentaur(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int though, int mighty, int size, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, "Centaur, " + rules, though, mighty, size, army)
        {
            armour = new UnArmoured();
        }
        public BaseCentaur(BaseCentaur input):base(input)
        {
            armour = new UnArmoured();
        }
        public override BaseUnit Clone()
        {
            return new BaseCentaur(this);
        }
        public override bool CanAddItem(Equipment equipment)
        {
            if (equipment is Armour)
            {
                return true; 
            }
            return base.CanAddItem(equipment);
        }
        public override void ResetEquipment()
        {
            armour = new UnArmoured();
            base.ResetEquipment();
        }
        public override void EquipUnit(Equipment input)
        {
            if (input is Armour)
            {
                armour = input as Armour;
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
            return output;
        }
        public override int GetCost()
        {
            return base.GetCost() + armour.Cost();
        }
    }
}
