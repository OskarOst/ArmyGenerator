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
    class RoundUpNumberOfSoldierButton:NumberOfSoldierButton
    {
        public RoundUpNumberOfSoldierButton(Texture2D texture, int rows, int columns, int xPos, int yPos, SpriteFont font, int numberofSoldiers, SoundEffect crystalSound) : base(texture, rows, columns, xPos, yPos, font, numberofSoldiers, crystalSound)
        {
        }
        private int RoundDown(int toRound)
        {
            int closest = toRound - (toRound % 10);
            return (toRound - closest) * -1;
        }
        private int RoundUp(int toRound)
        {
            int closest = (10 - toRound % 10) + toRound;
            return  closest - toRound; 
        }
        public int Rounding(int input)
        {
            if (NumberOfSoldiers() > 0)
            {
                return RoundUp(input);
            }
            else
            {
                return RoundDown(input);
            }
        }
    }
}
