using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class NonHeroHumanoid:BaseHumanoid
    {
        private FieldFortification fieldFortification;
        public NonHeroHumanoid(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, army)
        {
            AddEquipment();
        }
        public NonHeroHumanoid(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, rules, army)
        {
            AddEquipment();
        }
        public NonHeroHumanoid(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, int though, int mighty, int size, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, though, mighty, size, army)
        {
            AddEquipment();
        }
        public NonHeroHumanoid(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int though, int mighty, int size, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, rules, though, mighty, size, army)
        {
            AddEquipment();
        }
        public NonHeroHumanoid(NonHeroHumanoid input) : base(input)
        {
            AddEquipment();
        }
        public override BaseUnit Clone()
        {
            return new NonHeroHumanoid(this);
        }
        public override void ResetEquipment()
        {
            AddEquipment();
            base.ResetEquipment();
        }
        public override bool CanAddItem(Equipment equipment)
        {
            if (equipment is FieldFortification)
            {
                return true; 
            }
            return base.CanAddItem(equipment);
        }
        private void AddEquipment()
        {
            fieldFortification = new NoFortifications();
        }
        public override List<Equipment> GetEquipment()
        {
            List<Equipment> output = base.GetEquipment();
            output.Add(fieldFortification);
            return output;
        }
        public override void EquipUnit(Equipment input)
        {
            if (input is FieldFortification)
            {
                fieldFortification = input as FieldFortification;
            }
            else
            {
                base.EquipUnit(input);
            }
        }
        public override int GetCost()
        {
            if (fieldFortification.ArcherPlatform())
            {
                return base.GetCost() + fieldFortification.Cost();
            }
            else
            {
                return base.GetCost();
            }
        }
    }
}
