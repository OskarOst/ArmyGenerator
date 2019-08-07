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
    class ScreenSize
    {
        List<ScreenSizeButton> sizeButtons;
        private Vector2 savedWindowSize;
        public ScreenSize(Texture2D armyButtons, SpriteFont font, Texture2D decoration, SoundEffect bookSound, int width, int height, int ypos)
        {
            savedWindowSize = new Vector2(width, height);
            sizeButtons = new List<ScreenSizeButton>();
            sizeButtons.Add(new ScreenSizeButton(armyButtons, 1, 2, width/2 + 20, ypos, font, "1600 x 900", bookSound, 1600, 900));
            sizeButtons.Add(new ScreenSizeButton(armyButtons, 1, 2, width / 2 + 20, ypos + 50, font, "1920 x 1080", bookSound, 1920, 1080));
        }
        public void Resize(int xpos, int ypos)
        {
            for (int i = 0; i < sizeButtons.Count; i++)
            {
                sizeButtons[i].Repos(xpos, ypos + 50 * i);
            }
        }
        public void Update(MouseState mouseState, MouseState oldMouseState)
        {
            for (int i = 0; i < sizeButtons.Count; i++)
            {
                sizeButtons[i].Update(mouseState, oldMouseState);
            }
        }
        public bool WillChangeSize()
        {
            for (int i = 0; i < sizeButtons.Count; i++)
            {
                if (sizeButtons[i].pressed)
                {
                    return true;
                }
            }
            return false;
        }
        public string GetSize()
        {
            for (int i = 0; i < sizeButtons.Count; i++)
            {
                if (sizeButtons[i].pressed)
                {
                    return sizeButtons[i].GetText();
                }
            }
            return null;
        }
        public Vector2 GetWindowSize()
        {
            for (int i = 0; i < sizeButtons.Count; i++)
            {
                if (sizeButtons[i].pressed)
                {
                    savedWindowSize = sizeButtons[i].GetWindowSize();
                    return sizeButtons[i].GetWindowSize();
                }
            }
            return new Vector2(0, 0);
        }
        public Vector2 GetVectorSaved()
        {
            return savedWindowSize;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < sizeButtons.Count; i++)
            {
                sizeButtons[i].Draw(spriteBatch);
            }
        }
    }
}
