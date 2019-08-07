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
    enum SettingsWindows
    {
        None,
        ScreenDimensions
    }
    class GraphicsSetting
    {
        ScreenSize screenSize;
        Button screenSizebtn;
        Button fullScreenbtn;
        Button exitbtn;
        MouseState oldMouseState;
        SettingsWindows SettingsWindows;
        public GraphicsSetting(Texture2D armyButtons, SpriteFont font, Texture2D decoration, SoundEffect bookSound, int width, int height)
        {
            SettingsWindows = SettingsWindows.None;

            screenSizebtn = new Button(armyButtons, 1, 2, 150, 100, font, "ScreenSize", bookSound);
            fullScreenbtn = new Button(armyButtons, 1, 2, 150, 150, font, "Fullscreen", bookSound);
            exitbtn = new Button(armyButtons, 1, 2, 150, 200, font, "Return to Army", bookSound);

            screenSize = new ScreenSize(armyButtons, font, decoration, bookSound, width, height, 100);
        }
        public void Resize(int xpos)
        {
            screenSize.Resize(xpos, screenSizebtn.mainRec.Y);
        }
        public void Update(MouseState mouseState)
        {
            screenSizebtn.Update(mouseState, oldMouseState);
            fullScreenbtn.Update(mouseState, oldMouseState);
            exitbtn.Update(mouseState, oldMouseState);
            if (screenSizebtn.pressed)
            {
                SettingsWindows = SettingsWindows.ScreenDimensions;
            }
            if (SettingsWindows == SettingsWindows.ScreenDimensions)
            {
                screenSize.Update(mouseState, oldMouseState);
            }
            oldMouseState = mouseState;
        }

        public string GetSize()
        {
            return screenSize.GetSize();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            screenSizebtn.Draw(spriteBatch);
            fullScreenbtn.Draw(spriteBatch);
            exitbtn.Draw(spriteBatch);
            if (SettingsWindows == SettingsWindows.ScreenDimensions)
            {
                screenSize.Draw(spriteBatch);
            }
        }
        public bool FullscreenPressed()
        {
            return fullScreenbtn.pressed;
        }
        public bool ExitButtonPressed()
        {
            return exitbtn.pressed;
        }
        public Vector2 ReturnSavedWindowSize()
        {
            return screenSize.GetVectorSaved();
        }
        public bool WillChangeSize()
        {
            if (screenSize.WillChangeSize())
            {
                return true;
            }
            return false;
        }
        public Vector2 GetWindowSize()
        {
            return screenSize.GetWindowSize();
        }
    }
}
