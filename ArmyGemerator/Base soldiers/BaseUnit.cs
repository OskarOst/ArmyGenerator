using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
namespace ArmyGenerator
{
    [Serializable]
    class BaseUnit
    {
        public int cost;
        public int fight;
        public int shoot;
        public int defence;
        public int courage;
        public int discipline;
        public int minSpeed;
        public int maxSpeed;
        public string name;
        public string rules;
        public bool loner;
        public int though;
        public int mighty;
        private int army;
        public int size;

        public BaseUnit(BaseUnit Copy)
        {
            this.loner = Copy.loner;
            this.cost = Copy.cost;
            this.fight = Copy.fight;
            this.shoot = Copy.shoot;
            this.defence = Copy.defence;
            this.courage = Copy.courage;
            this.discipline = Copy.discipline;
            this.minSpeed = Copy.minSpeed;
            this.maxSpeed = Copy.maxSpeed;
            this.name = Copy.name;
            this.rules = Copy.rules;
            this.army = Copy.army;
            this.though = Copy.though;
            this.mighty = Copy.mighty;
            this.size = Copy.size;
        }
        public BaseUnit(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, int army)
        {
            loner = false;
            this.cost = cost;
            this.fight = fight;
            this.shoot = shoot;
            this.defence = defence;
            this.courage = courage;
            this.discipline = discipline;
            this.minSpeed = minSpeed;
            this.maxSpeed = maxSpeed;
            this.name = name;
            this.rules = "";
            this.army = army;
            though = 0;
            mighty = 0;
            size = 1;
        }
        public virtual List<SpellsClass> GetSpells()
        {
            return null;
        }
        public BaseUnit(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int army): this(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed,name, army)
        {
            this.rules = rules;
            if (rules.Contains("Loner"))
            {
                loner = true;
            }
        }
        public bool Loner()
        {
            return loner;
        }
        public BaseUnit(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, int though, int mighty, int size, int army) : this(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, army)
        {
            this.though = though;
            this.size = size;
            this.mighty = mighty;
        }
        public BaseUnit(int cost, int fight, int shoot, int defence, int courage, int discipline, int minSpeed, int maxSpeed, string name, string rules, int though, int mighty, int size, int army) : this(cost, fight, shoot, defence, courage, discipline, minSpeed, maxSpeed, name, army)
        {
            this.rules = rules;
            this.though = though;
            this.mighty = mighty;
            this.size = size;
            if (rules.Contains("Loner"))
            {
                loner = true;
            }
        }
        public string Text(SpriteFont font)
        {
            return Text(GetStats(), though, mighty, size, GetEquipment(), font);
        }
        public virtual bool IsSpellcaster()
        {
            return false;
        }
        public virtual void AddSpell(SpellsClass input)
        {
        }
        public List<int> returnListStats()
        {
            return new List<int>() {fight, shoot, defence, courage, discipline, minSpeed, maxSpeed };
        }
        public virtual string Text(List<int> input, int though, int mighty, int size, List<Equipment> equipment, SpriteFont font)
        {
            for (int y = 0; y < equipment.Count; y++)
            {
                if (equipment[y] != null)
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        input[i] = equipment[y].ModifyStats(input[i], i);
                    }
                    though = equipment[y].ModifyStats(though, 7);
                    mighty = equipment[y].ModifyStats(mighty, 8);
                    size = equipment[y].ModifyStats(size, 9);
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
                    though = equipment[y].ModifyStats2(though, 7);
                    mighty = equipment[y].ModifyStats2(mighty, 8);
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
            if (though > 0)
            {
                tempRules += ", Tough (" + though.ToString() + ")";
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
                tempRules += ", Large presence (" + size.ToString() + ")"; 
            }
            tempRules += ", " + rules;
            while (tempRules[0] == ' ' || tempRules[0] == ',')
            {
                tempRules = tempRules.Remove(0,1);
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
                    float check = font.MeasureString(tempLine  + tempArray[i] + ",").X;
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
            return text;
        }
        public virtual bool CanAddItem(Equipment equipment)
        {
            return false;
        }
        public List<int> GetStats()
        {
            return new List<int> { fight, shoot, defence, courage, discipline, minSpeed, maxSpeed };
        }
        public virtual List<Equipment> GetEquipment()
        {
            return new List<Equipment>();
        }
        public virtual int GetCost()
        {
            return cost;
        }
        public int GetArmy()
        {
            return army;
        }
        public virtual void ResetEquipment()
        {
        }
        public virtual string GetRules()
        {
            string rulesOutput = rules;
            if (though > 0)
            {
                rulesOutput += ", Tough (" + though.ToString() + ")";
            }
            if (mighty > 0)
            {
                if (mighty == 1)
                {
                    rulesOutput += ", Mighty";
                }
                else
                {
                    rulesOutput += ", Very Mighty";
                }
            }
            if (size > 1)
            {
                rulesOutput += ",  Large Presence (" + size.ToString() + ")";
            }
            return rulesOutput;
        }
        public virtual void RemoveEquipment(Equipment output)
        {
        }
        public virtual void EquipUnit(Equipment input)
        {
        }
        public string Name()
        {
            return name;
        }
        public virtual int GetOneTimeCost()
        {
            return 0; 
        }
        public virtual BaseUnit Clone()
        {
            return (new BaseUnit(this));
        }
        public virtual bool Commonplace()
        {
            return false;
        }
        public int Endsize()
        {
            int endSize = size;
            for (int i = 0; i < GetEquipment().Count; i++)
            {
                if (GetEquipment()[i] != null)
                {
                    if (endSize < GetEquipment()[i].Size())
                    {
                        endSize = GetEquipment()[i].Size();
                    }
                }
            }
            return endSize;
        }
        public virtual int GetArcherPlatformCost(int numberOfSoldiers)
        {
            int output = 0;
            int tempout;
            int tempcount;
            List<Equipment> equipment = GetEquipment();
            for (int i = 0; i < equipment.Count; i++)
            {
                if (equipment[i] != null)
                {
                    if (equipment[i].ArcherPlatform())
                    {
                        tempcount = 0;
                        tempout = numberOfSoldiers;
                        while (tempout > 0)
                        {
                            tempcount++;
                            tempout -= equipment[i].GetArcherPlatformSize();
                        }
                        output += equipment[i].Cost() * tempcount;
                    }
                }
            }
            return output;
        }
    }
}
