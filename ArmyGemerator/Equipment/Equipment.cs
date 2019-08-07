using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Equipment
    {
        private int cost;
        private int defenceModifier;
        private int fightModifier;
        private int diciplineModifier;
        private int shootModifier;

        private int lowspeedModifier;
        private int highSpeedModifier;
        private int mightyModifier;
        private int thougModifier;
        private int heroModifier;
        private int leaderModifier;
        private int manaModifier;
        private int spellModifier;

        private int absoluteSize;
        private int absoluteLowSpeed;
        private int absolutehighSpeed;
        private int absoluteTough;
        private int absoluteMighty;

        private string name;
        private string description;
        private int archerPlatform;

        public Equipment()
        {
        }
        public Equipment(int cost, string description, string name, int defenceModifier, int fightModifier, int diciplineModifier, int shootModifier, int lowspeedModifier, int highSpeedModifier,
            int mightyModifier, int thougModifier, int heroModifier, int leaderModifier, int manaModifier, int spellModifier, int absoluteSize, int absoluteLowSpeed, int absolutehighSpeed, 
            int absoluteTough, int absoluteMighty, int archerPlatform)
        {
            this.cost = cost;
            this.description = description;
            this.name = name;
            this.defenceModifier = defenceModifier;
            this.fightModifier = fightModifier;
            this.diciplineModifier = diciplineModifier;
            this.shootModifier = shootModifier;
            this.lowspeedModifier = lowspeedModifier;
            this.highSpeedModifier = highSpeedModifier;
            this.mightyModifier = mightyModifier;
            this.thougModifier = thougModifier;
            this.heroModifier = heroModifier;
            this.leaderModifier = leaderModifier;
            this.manaModifier = manaModifier;
            this.absoluteSize = absoluteSize;
            this.absoluteLowSpeed = absoluteLowSpeed;
            this.absolutehighSpeed = absolutehighSpeed;
            this.absoluteTough = absoluteTough;
            this.absoluteMighty = absoluteMighty;
            this.archerPlatform = archerPlatform;
        }
        public void SetStats(int cost, string description, string name, int defenceModifier, int fightModifier, int diciplineModifier, int shootModifier, int lowspeedModifier, int highSpeedModifier,
            int mightyModifier, int thougModifier, int heroModifier, int leaderModifier, int manaModifier, int spellModifier, int absoluteSize, int absoluteLowSpeed, int absolutehighSpeed,
            int absoluteTough, int absoluteMighty, int archerPlatform)
        {
            this.cost = cost;
            this.description = description;
            this.name = name;
            this.defenceModifier = defenceModifier;
            this.fightModifier = fightModifier;
            this.diciplineModifier = diciplineModifier;
            this.shootModifier = shootModifier;
            this.lowspeedModifier = lowspeedModifier;
            this.highSpeedModifier = highSpeedModifier;
            this.mightyModifier = mightyModifier;
            this.thougModifier = thougModifier;
            this.heroModifier = heroModifier;
            this.leaderModifier = leaderModifier;
            this.manaModifier = manaModifier;
            this.spellModifier = spellModifier;
            this.absoluteSize = absoluteSize;
            this.absoluteLowSpeed = absoluteLowSpeed;
            this.absolutehighSpeed = absolutehighSpeed;
            this.absoluteTough = absoluteTough;
            this.absoluteMighty = absoluteMighty;
            this.archerPlatform = archerPlatform;
        }
        public int ModifyStats(int input, int ID)
        {
            if (ID == 1)
            {
                input -= shootModifier;
            }
            else if (ID == 2)
            {
                input -= defenceModifier;
            }
            else if (ID == 4)
            {
                input -= diciplineModifier;
            }
            else if (ID == 5)
            {
                if (input < absoluteLowSpeed)
                    input = absoluteLowSpeed;
            }
            else if (ID == 6)
            {
                if (input < absolutehighSpeed)
                    input = absolutehighSpeed;
            }
            else if (ID == 7)
            {
                input += thougModifier;
            }
            else if (ID == 8)
            {
                input += mightyModifier;
            }
            else if (ID == 9)
            {
                if (input < absoluteSize)
                    input = absoluteSize;
            }
            else if (ID == 10)
            {
                input += manaModifier;
            }
            else if (ID == 11)
            {
                input += spellModifier;
            }
            else if (ID == 12)
            {
                input += heroModifier;
            }
            else if (ID == 13)
            {
                input += leaderModifier;
            }
            return input;
        }
        public int Size()
        {
            return absoluteSize;
        }
        public int ModifyStats2(int input, int ID)
        {
            if (ID == 5)
            {
                input += lowspeedModifier;
            }
            else if (ID == 6)
            {
                input += highSpeedModifier;
            }
            else if (ID == 7)
            {
                if (input < absoluteTough)
                {
                    input = absoluteTough;
                }
            }
            else if (ID == 8)
            {
                if (input < absoluteMighty)
                {
                    input = absoluteMighty;
                }
            }
            else if (ID == 9)
            {
                if (input < absoluteSize)
                {
                    input = absoluteSize;
                }
            }
            return input;
        }
        public int Cost()
        {
            return cost;
        }
        public bool ArcherPlatform()
        {
            if (archerPlatform > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetArcherPlatformSize()
        {
            return archerPlatform;
        }
        public string GetText()
        {
            return description;
        }
        public string GetName()
        {
            return name;
        }
        public virtual bool WriteAsEquipment()
        {
            return true;
        }
    }
}
