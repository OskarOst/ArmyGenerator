using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
namespace ArmyGenerator
{
    class TextHandler
    {
        private NumberHandler numberHandler;
        public TextHandler()
        {
            numberHandler = new NumberHandler();
        }
        public string NameText(BaseUnit soldier, int numberOfSoldiers, SpriteFont font, int endcost)
        {
            string text = soldier.Name();
            text += soldier.Text(font);
            if (soldier is BaseHumanoid|| soldier is Beast || soldier is CentaurSoldier || soldier is DryadSoldier)
            {
                text += "Total of Soldiers: " + numberOfSoldiers.ToString() + System.Environment.NewLine +
                "Cost of Regiment: " + endcost + " pts" + System.Environment.NewLine;
            }
            return text;
        }
        public string Rules(string input, SpriteFont font, float scale)
        {
            string output = "";
            string[] split = input.Split(',');
            List<string> outputList = new List<string>();
            string temp = "";
            for(int i =0; i < split.Length; i++)
            {
                if(font.MeasureString(temp + split[i] + ", ").X * scale < 570)
                {
                    temp = temp + split[i] + ", ";
                }
                else
                {
                    outputList.Add(temp);
                    temp = split [i];
                    if(temp[0] == ' ')
                    {
                        temp = temp.Remove(0, 1);
                    }
                }
            }
            outputList.Add(temp);
            for (int i = 0; i < outputList.Count; i++)
            {
                output += Environment.NewLine + outputList[i];
            }
            return output;
        }
        public string Tough(BaseUnit soldier, List<Equipment> equipment)
        {
            return "Though 0";
        }
        private string Text(string inputstring, int input)
        {
            string output = inputstring + "(";
            output = output + input.ToString() + "), ";
            if (input == 0)
            {
                output = "";
            }
            return output;
        }
    }
}
