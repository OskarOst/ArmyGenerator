using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArmyGenerator
{
    [Serializable]
    class Regiment
    {
        private BaseUnit soldier; 
        private int numberOfSoldiers;
        private int endCost;
        private int slot;
        private List<string> tempText = new List<string>();
        private string name;
        public Regiment()
        {
            soldier = null;
            tempText = new List<string>();
            name = "";
            numberOfSoldiers = 1;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public List<SpellsClass> GetSpellList()
        {
            return soldier.GetSpells();
        }
        public int EndCost()
        {
            return endCost;
        }
        public void AddSpell(SpellsClass input)
        {
            soldier.AddSpell(input);
        }
        public void AppointSoldier(BaseUnit soldier)
        {
            if (this.soldier != null)
            {
                List<Equipment> equipment = this.soldier.GetEquipment();
                this.soldier = soldier;
                for (int i = 0; i < equipment.Count(); i++)
                {
                    this.soldier.EquipUnit(equipment[i]);
                }
                if (this.soldier.loner)
                {
                    numberOfSoldiers = 1;
                }
            }
            else
            {
                this.soldier = soldier;
            }
        }
        public bool SolidUnit()
        {
            if (numberOfSoldiers * soldier.Endsize() >= 16)
            {
                return true;
            }
            return false;
        }
        public void SetSlot()
        {
            if (soldier is BaseHero || soldier is CentaurHero || soldier is DryadHero || soldier is Artilleryman || (soldier.Endsize() > 2 && !soldier.Commonplace()))
            {
                slot = -1;
            }
            else if (SolidUnit())
            {
                slot = 1;
            }
            else
            {
                slot = 0;
            }
        }
        public int Slots()
        {
            return slot;
        }
        public void ChangeNumberOfSoldiers(int i)
        {
            numberOfSoldiers += i;
            if (numberOfSoldiers < 1)
            {
                numberOfSoldiers = 1;
            }
            else if (numberOfSoldiers > 40)
            {
                numberOfSoldiers = 40;
            }
        }
        public BaseUnit ReturnType()
        {
            return soldier;
        }
        public void SetCost(int i)
        {
            endCost = i;
        }
        public int GetNumberOfSoldiers()
        {
            return numberOfSoldiers;
        }
        public string GetName()
        {
            if (name == null || name == "")
            {
                return ReturnName();
            }
            return name;
        }
        public BaseUnit GetSoldier()
        {
            return soldier;
        }
        public int GetSoldierCost()
        {
            return soldier.cost;
        }
        public string ReturnName()
        {

            if (soldier == null)
            {
                return null;
            }
            return soldier.Name();
        }
        public int GetSlots()
        {
            return 0;
        }
        public List<Equipment> GetEquipment()
        {
            return soldier.GetEquipment();
        }
        public void SetEquipment(Equipment input)
        {
            soldier.EquipUnit(input);

        }
        public void RemoveEquipment(Equipment input)
        {
            soldier.RemoveEquipment(input);
        }
        public int Textsize()
        {
            if (tempText != null)
            {
                if (tempText.Count != 0)
                    return tempText.Count;
            }
            return 0;
        }
        public int GetEndCost()
        {
            return endCost;
        }
        public Regiment GetCopy()
        {
            Regiment copy = (Regiment)this.MemberwiseClone();
            return copy;
        }
        public string GetText(SpriteFont font)
        {
            string output = "";
            if (name != "")
            {

                output = name + " (" ;
                string tempname = soldier.Name();
                if (numberOfSoldiers > 1)
                {
                    if (tempname.Contains("at-arm"))
                    {
                        if(tempname.Contains("Man-at"))
                        tempname  = tempname.Replace("Man-at", "Men-at");
                        else if (tempname.Contains("Elf-at"))
                            tempname = tempname.Replace("Elf-at", "Elves-at");
                        else if (tempname.Contains("Hafling-at"))
                            tempname = tempname.Replace("Hafling-at", "Haflings-at");
                    }
                    else
                    {
                        tempname += "s";
                    }
                }
                output += tempname + "("+numberOfSoldiers.ToString() + ")) " + endCost.ToString() + " pts";
            }
            else
            {
                output = soldier.Name();
                if (numberOfSoldiers > 1)
                {
                    if (output.Contains("at-arm"))
                    {
                        if (output.Contains("Man-at"))
                            output = output.Replace("Man-at", "Men-at");
                        else if (output.Contains("Elf-at"))
                            output = output.Replace("Elf-at", "Elves-at");
                        else if (output.Contains("Hafling-at"))
                            output = output.Replace("Hafling-at", "Haflings-at");
                    }
                    else
                    {
                        output += "s";
                    }
                }
                output += " (" + numberOfSoldiers.ToString() + ")  " + endCost.ToString() + " pts";
                for (int i = 0; i < soldier.GetEquipment().Count; i++)
                {
                    if (soldier.GetEquipment()[i] != null)
                    {
                        if (soldier.GetEquipment()[i] is Veteran && !(soldier.GetEquipment()[i] is GenericVeteran))
                        {
                            output = soldier.GetEquipment()[i].GetName() + " " + output;
                        }
                    }
                }
            }
            return output;
        }
        public string GetFullText(SpriteFont font, int cutOffLenght)
        {
            string output = soldier.Name() + " (" + numberOfSoldiers+")" + Environment.NewLine + soldier.Text(font) + Environment.NewLine + "Equipment: " + Environment.NewLine;
            string tempEquipment = "";
            for (int i = 0; i < soldier.GetEquipment().Count; i++)
            {
                if (soldier.GetEquipment()[i] != null)
                {
                    if (soldier.GetEquipment()[i].WriteAsEquipment())
                    {
                        string testString = soldier.GetEquipment()[i].GetName();
                        int testlenght = (int)font.MeasureString(tempEquipment + soldier.GetEquipment()[i].GetName() + ", ").X;
                        if (i + 1 == soldier.GetEquipment().Count)
                        {
                            tempEquipment += soldier.GetEquipment()[i].GetName();
                            output += tempEquipment + Environment.NewLine;
                        }
                        else if((int)font.MeasureString(tempEquipment + soldier.GetEquipment()[i].GetName() + ", ").X < cutOffLenght)
                        {
                            tempEquipment += soldier.GetEquipment()[i].GetName() + ", ";
                        }
                        else
                        {
                            output += tempEquipment + Environment.NewLine;
                            tempEquipment = soldier.GetEquipment()[i].GetName() + ", ";
                        }
                    }
                }
                else if (i + 1 == soldier.GetEquipment().Count)
                {
                    output += tempEquipment + Environment.NewLine;
                }
            }
            output += Environment.NewLine + "Special Rules: " + Environment.NewLine + soldier.GetRules();
            return output;
        }
        public void Draw()
        {

        }
        public void Update()
        {

        }
    }
}
