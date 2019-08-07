using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;
namespace ArmyGenerator
{
    class Name
    {
        private Button name;
        private Button cancel;
        private SpriteFont font;
        private Texture2D armyButtons;
        private WriteClass write;
        private string nametxt;
        KeyboardState keyboard;
        KeyboardState oldkeyboard;
        SoundEffect booksound;
        public Name(Texture2D armyButtons, Texture2D line, SpriteFont font, Texture2D decoration, int i, SoundEffect booksound)
        {
            this.booksound = booksound;
            write = new WriteClass(font, line, 200,100);
            this.armyButtons = armyButtons;
            this.font = font;
            name = new Button(armyButtons, 1, 2, 110, 750, font, "Name Unit", booksound);
            cancel = new Button(armyButtons, 1, 2, 310, 750, font, "Cancel Naming", booksound);
            nametxt = "";
        }
        public void Update(MouseState mouse, MouseState oldMouse, Regiment regiment, string unitType)
        {
            keyboard = Keyboard.GetState();
            name.Update(mouse, oldMouse);
            cancel.Update(mouse, oldMouse);
            write.Update(keyboard, oldkeyboard);
            nametxt = write.GetText();
            oldkeyboard = keyboard;
        }
        public bool Cancel()
        {
            if (cancel.pressed)
            {
                return true;
            }
            return false;
        }
        public bool ReturnName()
        {
            if (name.pressed)
            {
                return true;
            }
            return false;
        }
        public string GetName()
        {
            return nametxt;
        }
        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            cancel.Draw(spriteBatch);
            name.Draw(spriteBatch);
            write.Draw(spriteBatch, "");
        }
    }
}
