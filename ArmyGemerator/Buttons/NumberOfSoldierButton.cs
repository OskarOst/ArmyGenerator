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
    class NumberOfSoldierButton : Button
    {
        private int numberofSoldiers;
        public NumberOfSoldierButton(Texture2D texture, int rows, int columns, int xPos, int yPos, SpriteFont font, int numberofSoldiers, SoundEffect crystalSound) : base(texture, rows, columns, xPos, yPos, font, "", crystalSound, 0.5f)
        {
            this.numberofSoldiers = numberofSoldiers;
        }
        public void Sound()
        {

        }
        public int NumberOfSoldiers()
        {
            return numberofSoldiers;
        }
    }
}
