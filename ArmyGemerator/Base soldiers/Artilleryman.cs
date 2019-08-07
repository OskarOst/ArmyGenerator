using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace ArmyGenerator
{
    [Serializable]
    class Artilleryman : NonHeroHumanoid
    {
        private Artillery artillerypiece;
        private ArtilleryEngineer engineer;
        public Artilleryman(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, army)
        {
            AddEquipment();
        }
        public Artilleryman(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, rules, army)
        {
            AddEquipment();
        }
        public Artilleryman(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int tough, int mighty, int size, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, rules, tough, mighty, size, army)
        {
            AddEquipment();
        }
        public Artilleryman(Artilleryman input) : base(input)
        {
            AddEquipment(); 
        }
        public override BaseUnit Clone()
        {
            return new Artilleryman(this);
        }
        public override void ResetEquipment()
        {
            AddEquipment();
            base.ResetEquipment();
        }
        private void AddEquipment()
        {
            artillerypiece = new NoArtillery();
        }
        public override void EquipUnit(Equipment input)
        {
            if (input is Artillery)
            {
                artillerypiece = input as Artillery;
            }
            else if (input is ArtilleryEngineer)
            {
                engineer = input as ArtilleryEngineer;
            }
            else
            {
                base.EquipUnit(input);
            }
        }
        public override List<Equipment> GetEquipment()
        {
            List<Equipment> output = base.GetEquipment();
            output.Add(engineer);
            output.Add(artillerypiece);
            return output;
        }
        public override bool CanAddItem(Equipment equipment)
        {
            if (equipment is Artillery|| equipment is ArtilleryEngineer)
            {
                return true;
            }
            return base.CanAddItem(equipment);
        }
        public override void RemoveEquipment(Equipment output)
        {
            if (output is Artillery)
            {
                artillerypiece = new NoArtillery();
            }
            else if (output is ArtilleryEngineer)
            {
                engineer = null;
            }
            else
            {
                base.RemoveEquipment(output);
            }
        }
        public override int GetOneTimeCost()
        {
            int leadercost = 0;
            if (engineer != null)
            {
                leadercost += engineer.Cost();
            }
            return base.GetOneTimeCost() + artillerypiece.Cost() + leadercost;
        }
    }
}
