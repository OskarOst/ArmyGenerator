using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class DryadSoldier:BaseDryad
    {
        private FieldFortification fieldFortification;
        private Veteran veteranRule;
        private UnitLeader champion;
        private BannerBearer bannerBearer;
        private Muscicians muscician;
        public DryadSoldier(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, army)
        {
            EquipSoldier();
        }
        public DryadSoldier(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, rules, army)
        {
            EquipSoldier();
        }
        public DryadSoldier(DryadSoldier input) : base(input)
        {
            EquipSoldier();
        }
        public override BaseUnit Clone()
        {
            return new DryadSoldier(this);
        }
        private void EquipSoldier()
        {
            fieldFortification = new NoFortifications();
            veteranRule = new GenericVeteran();
        }
        public override void ResetEquipment()
        {
            base.ResetEquipment();
            EquipSoldier();
        }
        public override bool CanAddItem(Equipment equipment)
        {
            if (equipment is FieldFortification || equipment is Veteran || equipment is UnitLeader || equipment is BannerBearer|| equipment is Muscicians)
            {
                return true;
            }
            return base.CanAddItem(equipment);
        }
        public override List<Equipment> GetEquipment()
        {
            List<Equipment> output = base.GetEquipment();
            output.Add(fieldFortification);
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
            else if (input is FieldFortification)
            {
                fieldFortification = input as FieldFortification;
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
        public override int GetCost()
        {
            if (fieldFortification.ArcherPlatform())
            {
                return base.GetCost() + veteranRule.Cost() + fieldFortification.Cost();
            }
            else
            {
                return base.GetCost() + veteranRule.Cost();
            }
            
        }
    }
}
