using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace ArmyGenerator
{
    class Line:AllFather
    {
        int countdown; 
        public Line(Texture2D texture, int x, int y):base(texture, 1, 2, x, y)
        {
            countdown = 0;
        }
        public void Update(int input)
        {
            countdown++;
            if(countdown == 30)
            {
                countdown = 0;
                currentFrame++;
                if(currentFrame == 2)
                {
                    currentFrame = 0; 
                }
            }
            mainRec.X = input + mainRec.Width;
        }
        public void Draw(SpriteBatch spriteBatch, int offset)
        {
            int row = (int)((float)currentFrame / (float)columns);
            int column = currentFrame % columns;
            Rectangle tempRec = mainRec;
            tempRec.X += offset;
            Rectangle sourceRec = new Rectangle(mainRec.Width * column, mainRec.Height * row, mainRec.Width, mainRec.Height);
            //spriteBatch.Draw(texture, tempRec, sourceRec, Color.White);
        }
    }
}
