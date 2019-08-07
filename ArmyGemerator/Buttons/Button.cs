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
    class Button : AllFather
    {
        SpriteFont font;
        string name;
        Vector2 stringPos;
        bool soundBool;
        SoundEffect sound;
        float soundvolume; 
        public Button(Texture2D texture, int rows, int columns, int xPos, int yPos, SpriteFont font, string name, SoundEffect bookSound) : base(texture, rows, columns, xPos, yPos)
        {
            soundvolume = 1.0f;
            soundBool = true;
            this.font = font;
            this.name = name;
            sound = bookSound;
            stringPos = new Vector2(mainRec.X + (mainRec.Width / 2) - ((int)font.MeasureString(name).X / 2), mainRec.Y + 9);
        }
        public Button(Texture2D texture, int rows, int columns, int xPos, int yPos, SpriteFont font, string name, SoundEffect bookSound, float input) : base(texture, rows, columns, xPos, yPos)
        {
            soundvolume = input;
            soundBool = true;
            this.font = font;
            this.name = name;
            int p = (int)font.MeasureString(name).X;
            sound = bookSound;
            stringPos = new Vector2(mainRec.X + (mainRec.Width / 2) - (p / 2), mainRec.Y + 9);
        }
        public override void Update(MouseState mouseState, MouseState oldMouseState)
        {
            base.Update(mouseState, oldMouseState);
            currentFrame = 0;
            if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released && mouseRec.Intersects(mainRec))
            {
                currentFrame = 1;
                if(soundBool == true)
                {
                    sound.Play(soundvolume, 0.0f, 1.0f);
                }
            }
        }
        public override void Repos(int x, int y)
        {
            base.Repos(x, y);
            stringPos = new Vector2(mainRec.X + (mainRec.Width / 2) - ((int)font.MeasureString(name).X / 2), mainRec.Y + 9);
        }
        public void Update(MouseState mouseState, MouseState oldMouseState, int i)
        {
            base.Update(mouseState, oldMouseState);
            if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released && mouseRec.Intersects(mainRec))
            {
                if (soundBool == true)
                {
                    sound.Play(soundvolume, 0.0f, 1.0f);
                }
            }
        }
        public string GetText()
        {
            return name;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(font, name, stringPos, Color.Black);
        }

    }
}
