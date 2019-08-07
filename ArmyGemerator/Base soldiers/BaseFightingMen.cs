using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace ArmyGenerator
{
    [Serializable]
    class BaseFightingMen : BaseUnit
    {
        private List<MeleeWeapons> meleeWeapons;
        private RangeWeapon rangeWeapon;

        public BaseFightingMen(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, army)
        {
            AddEquipment();
        }
        public BaseFightingMen(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, rules, army)
        {
            AddEquipment();
        }
        public BaseFightingMen(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, int though, int mighty, int size, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, though, mighty, size, army)
        {
            AddEquipment();
        }
        public BaseFightingMen(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int though, int mighty, int size, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, rules, though, mighty, size, army)
        {
            AddEquipment();
        }
        public BaseFightingMen(BaseFightingMen input):base (input)
        {
            AddEquipment();
        }
        public override BaseUnit Clone()
        {
            return new BaseFightingMen(this);
        }
        private void AddEquipment()
        {
            meleeWeapons = new List<MeleeWeapons>();
            meleeWeapons.Add(new SideArm());
            meleeWeapons.Add(null);
            meleeWeapons.Add(null);
            rangeWeapon = new GoodOldFists();
        }
        public override void ResetEquipment()
        {
            AddEquipment();
            base.ResetEquipment();
        }
        public override bool CanAddItem(Equipment equipment)
        {
            if (equipment is MeleeWeapons || equipment is RangeWeapon)
            {
                return true;
            }
            return base.CanAddItem(equipment);
        }
        public override List<Equipment> GetEquipment()
        {
            List<Equipment> output = base.GetEquipment();
            output.AddRange(meleeWeapons);
            output.Add(rangeWeapon);
            return output;
        }
        public override void EquipUnit(Equipment input)
        {
            if (input is RangeWeapon)
            {
                rangeWeapon = input as RangeWeapon;
            }
            else if (input is MeleeWeapons)
            {
                AddWeapon(input as MeleeWeapons);
            }
            else
            {
                base.EquipUnit(input);
            }
        }
        public override int GetCost()
        {
            int tempint = 0;
            for (int i = 0; i < meleeWeapons.Count; i++)
            {
                if (meleeWeapons[i] != null)
                {
                    tempint += meleeWeapons[i].Cost();
                }
            }
            return base.GetCost() + rangeWeapon.Cost() + tempint;
        }
        public override void RemoveEquipment(Equipment output)
        {
            if (output is RangeWeapon)
            {
                rangeWeapon = new GoodOldFists();
            }
            else if (output is MeleeWeapons)
            {
                for (int i = 0; i < meleeWeapons.Count; i++)
                {
                    if (meleeWeapons[i] == output)
                    {
                        meleeWeapons[i] = meleeWeapons[meleeWeapons.Count -1];
                        meleeWeapons[meleeWeapons.Count - 1] = null;
                    }
                }
                int p = 0; 
            }
            else
            {
                base.RemoveEquipment(output);
            }
        }
        private void AddWeapon(MeleeWeapons input)
        {
            for (int i = meleeWeapons.Count - 1; i > 0; i--)
            {
                if (meleeWeapons[i - 1] != null)
                {
                    meleeWeapons[i] = meleeWeapons[i - 1];
                }
            }
            meleeWeapons[0] = input;
        }
    }
}
