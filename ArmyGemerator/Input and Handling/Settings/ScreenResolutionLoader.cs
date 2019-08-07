using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace ArmyGenerator
{
    class ScreenResolutionLoader
    {
        List<int> output;
        List<float> floatOutput;
        public ScreenResolutionLoader(string input, Texture2D book)
        {
            output = new List<int>();
            floatOutput = new List<float>();
            string tempstring = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Screenresolutions\\" + input + ".txt");
            tempstring = tempstring.Replace("\r\n", "");
            tempstring = tempstring.Replace(" ", "");
            string[] temp = tempstring.Split(';');
            output.Add(Search(temp, "screenwidth"));
            output.Add(Search(temp, "screenheight") - 40 - 30);
            output.Add(Search(temp, "armyXStartPos"));
            output.Add(Search(temp, "armyYStartPos"));
            floatOutput.Add((float)((float)book.Height / (float)output[1]));
            floatOutput.Add((float)((float)book.Width / (float)output[0]));
            output.Add(Search(temp, "regimentCancel"));
            output.Add(Search(temp, "cutOffSize"));
            output.Add(Search(temp, "yStartPosMagic"));
            output.Add(Search(temp, "yCuttOff"));
            output.Add(Search(temp, "yStartRegimentLoad"));
            output.Add(Search(temp, "SwitchArmyButtonsPositionX"));
            output.Add(Search(temp, "SwitchArmyButtonsPositionY"));
            output.Add(Search(temp, "SwitchArmyButtonsPositionX2"));
            output.Add(Search(temp, "markButtonStartPos"));
            output.Add(Search(temp, "yStartPosMagic"));
            int p = 0;
        }
        public int GetNumber(int input)
        {
            return output[input];
        }
        public float GetFloat(int input)
        {
            return floatOutput[input];
        }
        public int Search(string [] input, string search)
        {
            string output;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Contains(search))
                {
                    output = input[i].Replace(search, "");
                    output = output.Replace("=","");
                    return Int32.Parse(output);
                }
            }
            return -69;
        }
    }
}
