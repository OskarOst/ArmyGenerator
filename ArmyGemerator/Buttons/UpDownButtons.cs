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
    class UpDownButtons : AllFather
    {
        public UpDownButtons(Texture2D texture, int rows, int columns, int xPos, int yPos, int frame) : base(texture, rows, columns, xPos, yPos)
        {
            currentFrame = frame;
        }
    }
}
