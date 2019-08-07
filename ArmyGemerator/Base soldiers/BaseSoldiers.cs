using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace ArmyGenerator
{
    [Serializable]
    class BaseSoldiers: NonHeroHumanoid
    {
        private Veteran veteranRule;
        private bool commonplace;
        private UnitLeader champion;
        private BannerBearer bannerBearer;
        private Muscicians muscician; 
        public BaseSoldiers(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, army)
        {
            AddEquipment();
        }
        public BaseSoldiers(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, rules, army)
        {
            AddEquipment();
            if (rules.Contains("Commonplace"))
            {
                commonplace = true;
            }
        }
        public BaseSoldiers(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, int though, int mighty, int size, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, though, mighty, size, army)
        {
            AddEquipment();
        }
        public BaseSoldiers(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int though, int mighty, int size, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, rules, though, mighty, size, army)
        {
            AddEquipment();
            if (rules.Contains("Commonplace"))
            {
                commonplace = true;
            }
        }
        public BaseSoldiers(BaseSoldiers input) : base(input)
        {
            AddEquipment();
            if (input.rules.Contains("Commonplace"))
            {
                commonplace = true;
            }
        }
        public override BaseUnit Clone()
        {
            return new BaseSoldiers(this);
        }
        public override void ResetEquipment()
        {
            AddEquipment();
            base.ResetEquipment();
        }
        public override bool CanAddItem(Equipment equipment)
        {
            if (equipment is Veteran || equipment is UnitLeader || equipment is BannerBearer || equipment is Muscicians)
            {
                return true;
            }
            return base.CanAddItem(equipment);
        }
        public override List<Equipment> GetEquipment()
        {
            List<Equipment> output = base.GetEquipment();
            output.Add(veteranRule);
            output.Add(champion);
            output.Add(muscician);
            output.Add(bannerBearer);
            return output;
        }
        public override void EquipUnit(Equipment input)
        {
            if (input is Veteran)
            {
                veteranRule = input as Veteran;
            }
            else if (input is UnitLeader)
            {
                champion = input as UnitLeader;
            }
            else if (input is BannerBearer)
            {
                bannerBearer = input as BannerBearer;
            }
            else if (input is Muscicians)
            {
                muscician = input as Muscicians;
            }
            else
            {
                base.EquipUnit(input);
            }

        }
        public override void RemoveEquipment(Equipment output)
        {
            if (output is UnitLeader)
            {
                champion = null;
            }
            else if (output is Muscicians)
            {
                muscician = null;
            }
            else if (output is BannerBearer)
            {
                bannerBearer = null;
            }
            else if (output is Veteran)
            {
                veteranRule = new GenericVeteran();
            }
            else
            {
                base.RemoveEquipment(output);
            }
        }
        public override int GetCost()
        {
            return base.GetCost() + veteranRule.Cost();
        }
        public override int GetOneTimeCost()
        {
            int leadercost = 0;
            if (champion != null)
            {
                leadercost += champion.Cost();
            }
            if (bannerBearer != null)
            {
                leadercost += bannerBearer.Cost();
            }
            if (muscician != null)
            {
                leadercost += muscician.Cost();
            }
            return base.GetOneTimeCost() + leadercost;
        }
        private void AddEquipment()
        {
            commonplace = false; 
            veteranRule = new GenericVeteran();
        }
    }
}
