using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArmyGenerator
{
    class Decoration : AllFather
    {
        public Decoration(Texture2D texture, int rows, int columns, int xPos, int yPos, int picture) : base(texture, rows, columns, xPos, yPos)
        {
            currentFrame = picture;
        }
    }
}
