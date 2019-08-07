using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class Army
    {
        private List<Regiment> regiments;
        private int totalCost;
        private int numberOfSlots;
        private int numbersOfSoldiers;
        public Army()
        {
            regiments = new List<Regiment>();
            numberOfSlots = 1;
        }
        public void AddRegiment(Regiment regiment)
        {
            regiment.SetSlot();
            regiments.Add(regiment);
            CalculateCost();
            CalculateMiniatureNumbers();
            CalculateSlots();
        }
        public void EditRegiment(Regiment regiment, int i)
        {
            regiments[i] = regiment;
        }
        public int CalculateSlots()
        {
            numberOfSlots = 1;
            for (int i = 0; i < regiments.Count; i++)
            {
                numberOfSlots += regiments[i].Slots();
            }
            return numberOfSlots;
        }
        public void CalculateCost()
        {
            totalCost = 0;
            for (int i = 0; i < regiments.Count; i++)
            {
                totalCost += regiments[i].GetEndCost();
            }
        }
        public int GetNumberOfSoldiers()
        {
            return numbersOfSoldiers;
        }
        public int GetTotalCost()
        {
            return totalCost;
        }
        public List<Regiment> getRegiments()
        {
            return regiments;
        }
        public void SortRegiments(Regiment input, int place, int move, int end)
        {
            if (place != 0 && place != end)
            {
                regiments[place] = regiments[place + move];
                regiments[place + move] = input;
            }

        }
        private void CalculateMiniatureNumbers()
        {
            numbersOfSoldiers = 0;
            for (int i = 0; i < regiments.Count; i++)
            {
                numbersOfSoldiers += regiments[i].GetNumberOfSoldiers();
            }
        }
        public int GetNumberOfSlots()
        {
            return numberOfSlots;
        }
        public Regiment GetRegimentClone(int i)
        {
            if (i > -1 && i < regiments.Count)
            {
                return regiments[i].GetCopy();
            }
            else
                return null;
        }
    }
}
