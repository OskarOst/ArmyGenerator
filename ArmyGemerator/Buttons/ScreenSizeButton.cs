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
    class ScreenSizeButton : Button
    {
        private Vector2 vector;
        public ScreenSizeButton(Texture2D texture, int rows, int columns, int xPos, int yPos, SpriteFont font, string name, SoundEffect bookSound, int windowWidth, int windowHeight) : base(texture, rows, columns, xPos, yPos, font, name, bookSound)
        {
            vector = new Vector2(windowWidth, windowHeight);
        }
        public Vector2 GetWindowSize()
        {
            return vector;
        }
    }
}
