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
    class AllFather
    {
        public Texture2D texture;
        public int currentFrame = 0;
        public int columns;
        public int rows;
        public Rectangle mainRec;
        public bool pressed = false;
        public Rectangle mouseRec = new Rectangle(0, 0, 1, 1);
        public int height;
        public int width;
        public AllFather(Texture2D texture, int rows, int columns, int xPos, int yPos)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            if (texture != null)
            {
                width = texture.Width / columns;
                height = texture.Height / rows;
                mainRec = new Rectangle(xPos, yPos, width, height);
            }
        }
        public virtual void Update(MouseState mouseState, MouseState oldMouseState)
        {
            pressed = false;
            mouseRec.X = (int)(mouseState.X);
            mouseRec.Y = (int)(mouseState.Y);
            if (mouseRec.Intersects(mainRec) && mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                pressed = true;
            }
        }
        public virtual void Repos(int x, int y)
        {
            mainRec.X = x;
            mainRec.Y = y;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            int row = (int)((float)currentFrame / (float)columns);
            int column = currentFrame % columns;
            Rectangle sourceRec = new Rectangle(width * column, height * row, width, height);
            spriteBatch.Draw(texture, mainRec, sourceRec, Color.White);
        }
    }
}
