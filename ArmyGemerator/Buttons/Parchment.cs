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
    class Parchment : AllFather
    {
        private string text;
        private bool exist;
        private int countdown;
        private int countdownEndTime;
        private Vector2 size;
        SpriteFont font;
        private int offset; 
        public Parchment(Texture2D texture, Vector2 size, SpriteFont font) : base(texture, 1, 1, 0, 0)
        {
            offset = 30;
            this.size = size;
            text = "";
            countdown = 0;
            countdownEndTime = 150;
            this.font = font; 
        }
        public void Create(int x, int y, Equipment equipment)
        {
            if (y + mainRec.Height > size.Y)
            {
                mainRec.Y = (int)(size.Y - mainRec.Height);
            }
            else
            {
                mainRec.Y = y;
            }
            if (x + mainRec.Width > size.X)
            {
                mainRec.X = (int)(size.X - mainRec.Width);
            }
            else
            {
                mainRec.X = x;
            }
            
            text = equipment.GetName() + Environment.NewLine + Environment.NewLine;
            string[] temp = equipment.GetText().Split(' ');
            string tempstring = temp[0];
            for (int i = 1; i < temp.Length; i++)
            {
                if (font.MeasureString(tempstring + " " + temp[i]).X > mainRec.Width - (offset*2))
                {
                    text += tempstring + Environment.NewLine;
                    tempstring = temp[i];
                }
                else
                {
                    tempstring += " " + temp[i];
                }
                if (i == temp.Length - 1)
                {
                    text += tempstring + Environment.NewLine;
                }
            }

            int a= 0; 
        }
        public bool Interact(Rectangle recangle)
        {
            if (recangle.Intersects(mainRec))
            {
                return true;
            }
            return false;
        }
        public bool Exist()
        {
            return exist;
        }
        public void Reset()
        {
            countdown = 0;
            exist = false;
        }
        public bool Countdown()
        {
            if (countdown < countdownEndTime)
            {
                countdown++;
                if (countdown == countdownEndTime)
                {
                    exist = true;
                    return true;
                }
            }
            return false;
        }
        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            if (exist)
            {
                base.Draw(spriteBatch);
                spriteBatch.DrawString(font, text, new Vector2(mainRec.X + offset, mainRec.Y + 60), Color.Black,
                0, new Vector2(0, 0), 1f, SpriteEffects.None, 1f);
            }
        }
    }
}
