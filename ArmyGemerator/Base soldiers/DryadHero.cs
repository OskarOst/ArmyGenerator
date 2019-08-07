using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace ArmyGenerator
{
    [Serializable]
    class DryadHero:BaseDryad
    {
        private List<HeroTraits> heroTraits;
        private List<SpellsClass> spellList;
        private int mana;
        private int hero;
        private int leader;
        private int spells;
        public DryadHero(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, army)
        {
            AddEquipment(0, 0, 0, 0);
        }
        public DryadHero(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, army)
        {
            AddEquipment(0, 0, 0, 0);
        }
        public DryadHero(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, int mana, int spells, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, army)
        {
            AddEquipment(mana, spells, 0, 0);

        }
        public DryadHero(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int mana, int spells, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, army)
        {
            AddEquipment(mana, spells, 0, 0);
        }
        public DryadHero(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int mana, int spells, int leader, int hero, int army) : base(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, army)
        {
            AddEquipment(mana, spells, leader, hero);
        }
        public DryadHero(DryadHero input) : base(input)
        {
            AddEquipment(input.mana, input.spells, input.leader, input.hero);
        }
        public override bool IsSpellcaster()
        {
            if (spells > 0)
            {
                return true;
            }
            return base.IsSpellcaster();
        }
        public override BaseUnit Clone()
        {
            return new DryadHero(this);
        }
        public override void ResetEquipment()
        {
            base.ResetEquipment();
            heroTraits = new List<HeroTraits>();
            heroTraits.Add(new GenericHero());
        }
        public override string Text(List<int> input, int though, int mighty, int size, List<Equipment> equipment, SpriteFont font)
        {
            int tempMana = mana;
            int tempSpells = spells;
            int temphero = hero;
            int tempLeader = leader;
            int tempTough = though;
            int tempsize = size;
            int tempMighty = mighty;
            for (int y = 0; y < equipment.Count; y++)
            {
                if (equipment[y] != null)
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        input[i] = equipment[y].ModifyStats(input[i], i);
                    }
                    tempTough = equipment[y].ModifyStats(tempTough, 7);
                    tempMighty = equipment[y].ModifyStats(tempMighty, 8);
                    tempsize = equipment[y].ModifyStats(size, 9);
                    tempMana += equipment[y].ModifyStats(0, 10);
                    tempSpells += equipment[y].ModifyStats(0, 11);
                    temphero += equipment[y].ModifyStats(0, 12);
                    tempLeader += equipment[y].ModifyStats(0, 13);
                }
            }
            for (int y = 0; y < equipment.Count; y++)
            {
                if (equipment[y] != null)
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        input[i] = equipment[y].ModifyStats2(input[i], i);
                    }
                    tempTough = equipment[y].ModifyStats2(tempTough, 7);
                    tempMighty = equipment[y].ModifyStats2(tempMighty, 8);
                    size = equipment[y].ModifyStats2(size, 9);
                }
            }
            List<string> textList = new List<string>();
            for (int i = 0; i < input.Count; i++)
            {
                if (i > 4)
                {
                    textList.Add(input[i].ToString());
                }
                else if (input[i] < 2)
                {
                    textList.Add("2+");
                }
                else if (input[i] > 100)
                {
                    textList.Add("-");
                }
                else if (input[i] > 6)
                {
                    textList.Add("6+");
                }
                else
                {
                    textList.Add(input[i].ToString() + "+");
                }
            }
            string text = System.Environment.NewLine +
            "Cost: " + cost + System.Environment.NewLine +
            "Fight: " + textList[0] + System.Environment.NewLine +
            "Shoot: " + textList[1] + System.Environment.NewLine +
            "Defence: " + textList[2] + System.Environment.NewLine +
            "Courage: " + textList[3] + System.Environment.NewLine +
            "Disipline: " + textList[4] + System.Environment.NewLine +
            "Speed: " + textList[5] + "/" + textList[6] + System.Environment.NewLine;
            string tempRules = "";
            if (tempTough > 0)
            {
                tempRules += ", Tough (" + tempTough.ToString() + ")";
            }
            if (mighty > 0)
            {
                if (mighty == 1)
                {
                    tempRules += ", Mighty";
                }
                else
                {
                    tempRules += ", Very Mighty";
                }
            }
            if (size > 1)
            {
                tempRules += ",  Large Presence (" + size.ToString() + ")";
            }
            tempRules += ", Hero: (" + temphero.ToString() + "), Leader: (" + tempLeader.ToString() + ")";
            if (tempMana > 0)
            {
                tempRules += ", Mana: (" + tempMana.ToString() + ")";
            }
            if (tempSpells > 0)
            {
                tempRules += ", Spells: (" + tempSpells.ToString() + ")";
            }
            tempRules += ", " + rules;
            while (tempRules[0] == ' ' || tempRules[0] == ',')
            {
                tempRules = tempRules.Remove(0, 1);
                if (tempRules.Length == 0)
                {
                    break;
                }
            }
            if (tempRules.Length > 0)
            {
                tempRules = "Special Rules: " + tempRules;

                string[] tempArray = tempRules.Split(',');
                tempRules = "";
                string tempLine = "";
                for (int i = 0; i < tempArray.Length; i++)
                {
                    float check = font.MeasureString(tempLine + tempArray[i] + ",").X;
                    if (font.MeasureString(tempLine + tempArray[i] + ",").X <= 800)
                    {
                        tempLine += tempArray[i] + ",";
                    }
                    else
                    {
                        tempRules += tempLine + System.Environment.NewLine;
                        tempLine = tempArray[i] + ",";
                    }
                }
                tempRules += tempLine;
            }
            text += tempRules + System.Environment.NewLine + System.Environment.NewLine;
            if (spellList.Count > 0)
            {
                text += "Spells known; ";
                for (int i = 0; i < spellList.Count; i++)
                {
                    if (spellList[i] != null)
                    {
                        text += spellList[i].GetName() + ", ";
                    }
                }
                text += System.Environment.NewLine;
            }
            return text;
        }
        private void AddEquipment(int mana, int spells, int leader, int hero)
        {
            heroTraits = new List<HeroTraits>();
            heroTraits.Add(new GenericHero());
            this.spellList = new List<SpellsClass>();
            if (spells > 0)
            {
                for (int i = 0; i < spells; i++)
                {
                    this.spellList.Add(null);
                }
            }
            this.mana = mana;
            this.spells = spells;
            this.hero = hero;
            this.mana = mana;
            though = 1;
            loner = true;
        }
        public override bool CanAddItem(Equipment equipment)
        {
            if (equipment is HeroTraits)
            {
                return true;
            }
            return base.CanAddItem(equipment);
        }
        public override void EquipUnit(Equipment input)
        {
            if (input is HeroTraits)
            {
                if (input is GenericHero)
                {
                    heroTraits.Clear();
                    heroTraits.Add(input as HeroTraits);
                }
                else
                {
                    if (heroTraits[0] is GenericHero)
                    {
                        heroTraits[0] = input as HeroTraits;
                    }
                    else if (heroTraits.Contains(input as HeroTraits))
                    {
                        heroTraits.Remove(input as HeroTraits);
                        if (heroTraits.Count == 0)
                        {
                            heroTraits.Add(new GenericHero());
                        }
                    }
                    else
                    {
                        heroTraits.Add(input as HeroTraits);
                    }
                }
            }
            else
            {
                base.EquipUnit(input);
            }
        }
        public override void RemoveEquipment(Equipment output)
        {
            if (output is HeroTraits)
            {
                heroTraits.Remove(output as HeroTraits);
                if (heroTraits.Count == 0)
                {
                    heroTraits.Add(new GenericHero());
                }
            }
            else
            {
                base.RemoveEquipment(output);
            }
        }
        public override int GetCost()
        {
            int tempCost = 0;
            if (!(heroTraits[0] is GenericHero))
            {
                for (int i = 0; i < heroTraits.Count; i++)
                {
                    tempCost += i + 1 * 20;
                }
            }
            return base.GetCost() + tempCost;
        }
        public override List<Equipment> GetEquipment()
        {
            List<Equipment> output = base.GetEquipment();
            output.AddRange(heroTraits);
            return output;
        }
        public override List<SpellsClass> GetSpells()
        {
            return spellList;
        }
        public override void AddSpell(SpellsClass input)
        {
            if (spellList.Contains(input))
            {
                for (int i = 0; i < spellList.Count(); i++)
                {
                    if (spellList[i] != null)
                    {
                        if (spellList[i].Equals(input))
                        {
                            for (int p = i; p < spellList.Count() - 1; p++)
                            {
                                spellList[p] = spellList[p + 1];
                            }
                            spellList[spellList.Count - 1] = null;
                            break;
                        }
                    }
                }
            }
            else
            {
                if (spellList.Contains(null))
                {
                    List<SpellsClass> temp = new List<SpellsClass>();
                    List<SpellsClass> temp2 = new List<SpellsClass>();
                    for (int i = 0; i < spellList.Count; i++)
                    {
                        if (spellList[i] == null)
                        {
                            temp2.Add(null);
                        }
                        else
                        {
                            temp.Add(spellList[i]);
                        }
                    }
                    spellList.Clear();
                    spellList.AddRange(temp);
                    spellList.AddRange(temp2);
                    for (int i = spellList.Count - 1; i >= 0; i--)
                    {
                        if (i - 1 < 0)
                        {
                        }
                        else if (spellList[i - 1] != null)
                        {
                            spellList[i] = input;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < spellList.Count - 1; i++)
                    {
                        spellList[i] = spellList[i + 1];
                    }
                }
                spellList[spellList.Count - 1] = input;
            }
        }

    }
}
