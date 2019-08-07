using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace ArmyGenerator
{
    class Save
    {
        public Button save;
        public Button cancel;
        public KeyboardState keyboard;
        public KeyboardState oldKeyboard;
        public string saveName;
        public WriteClass write;
        private string typeSave;
        public Save(Texture2D armyButtons, SpriteFont font, string typeSave, Texture2D decorationPic, int decorationPicNmr, SoundEffect booksound, Texture2D lineTexture)
        {
            this.typeSave = typeSave;
            write = new WriteClass(font, lineTexture, 200, 100);
            saveName = "";
            save = new Button(armyButtons, 1, 2, 250, 150, font, "Save " + typeSave, booksound);
            cancel = new Button(armyButtons, 1, 2, 450, 150, font, "Cancel", booksound);
        }
        public void Update(MouseState mouse, MouseState oldMouse, string savePath, Object input)
        {
            keyboard = Keyboard.GetState();
            save.Update(mouse, oldMouse);
            cancel.Update(mouse, oldMouse);
            write.Update(keyboard, oldKeyboard);
            saveName = write.GetText();
            if (save.pressed == true && saveName != "")
            {
                FileStream fileStream = null;
                try
                {
                    fileStream = new FileStream(savePath + "//" + saveName, FileMode.Create);
                    BinaryFormatter b = new BinaryFormatter();
                    b.Serialize(fileStream, input);
                    cancel.pressed = true;
                }
                finally
                {
                    if (fileStream != null)
                        fileStream.Close();
                }
            }
            oldKeyboard = keyboard;
        }
        public void Update(MouseState mouse, MouseState oldMouse, string savePath)
        {
            keyboard = Keyboard.GetState();
            save.Update(mouse, oldMouse);
            cancel.Update(mouse, oldMouse);
            write.Update(keyboard, oldKeyboard);
            saveName = write.GetText();
            if (save.pressed == true && saveName != "")
            {
                Directory.CreateDirectory(savePath + "\\" + saveName);
            }
            oldKeyboard = keyboard;
        }
        public bool Cancel()
        {
            if (cancel.pressed == true || save.pressed == true)
            {
                return true;
            }
            return false;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            save.Draw(spriteBatch);
            cancel.Draw(spriteBatch);
            write.Draw(spriteBatch, "Save " + typeSave + " as: ");
        }
    }
}
