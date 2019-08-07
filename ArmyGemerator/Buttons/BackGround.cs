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
    class BackGround : AllFather
    {
        public BackGround(Texture2D texture, int rows, int columns, int xPos, int yPos, int width, int height) : base(texture, rows, columns, xPos, yPos)
        {
            this.width = width;
            float tempModifier;
            if (width > texture.Width)
            {
                tempModifier = (float)width / (float)texture.Width;
                this.height = (int)(texture.Height * tempModifier);
            }
            else
            {
                tempModifier = (float)texture.Width / (float)width;
                this.height = (int)(height * tempModifier);
            }
            mainRec.Width = this.width;
            mainRec.Height = height;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, mainRec, Color.White);
        }
    }
}
