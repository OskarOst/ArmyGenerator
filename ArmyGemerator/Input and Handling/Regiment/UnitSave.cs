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
    class UnitSave : Save
    {
        List<MarkButton> buttons;
        private Save foldername;
        bool savebool;
        private Button newfolder;
        private Texture2D button;
        private SpriteFont font;
        SoundEffect clickSound;
        private string tempname;
        private Texture2D backGround;
        Rectangle backRec;
        SliderClass slider; 
        public UnitSave(Texture2D armyButtons, SpriteFont font, string typeSave, Texture2D decorationPic, int decorationPicNmr, Texture2D markButtons, 
            string savePath, SoundEffect clickSound, SoundEffect bookSound, Texture2D lineTexture, Texture2D backGround, int x, int y, Texture2D mark, Texture2D upDown) : base(armyButtons, font, typeSave, decorationPic, decorationPicNmr, bookSound, lineTexture)
        {
            backRec = new Rectangle(x, y+ 20, backGround.Width, backGround.Height);
            this.backGround = backGround;
            this.clickSound = clickSound;
            this.button = markButtons;
            this.font = font;
            buttons = new List<MarkButton>();
            write = new WriteClass(font, lineTexture, x, y);
            save = new Button(armyButtons, 1, 2, x, y + 20 + backGround.Height + 10, font, "Save Regiment", bookSound);
            cancel = new Button(armyButtons, 1, 2, x + save.mainRec.Width+ 10, y + 20 + backGround.Height + 10, font, "Cancel Save", bookSound);
            newfolder = new Button(armyButtons, 1, 2, x + (save.mainRec.Width + 10) * 2, y + 20 + backGround.Height + 10, font, "New Folder", bookSound);
            foldername = new Save(armyButtons, font, "Folder Path", decorationPic, 2, bookSound, lineTexture);
            slider = new SliderClass(mark, upDown, backGround.Height, 32, y + 20, x + backGround.Width - upDown.Width/4, y + 20 - upDown.Height, y + 20 + backGround.Height, x + backGround.Width - mark.Width / 2, 20);
            for (int i = 0; i < Directory.GetDirectories(savePath).Count(); i++)
            {
                string temp = Directory.GetDirectories(savePath)[i];
                temp = temp.Replace(savePath + "\\", "");
                buttons.Add(new MarkButton(markButtons, 3, 1, x + 5, y + 25 + (i * 20), temp, clickSound));
            }
            buttons[0].ChangeState();
            tempname = buttons[0].Text();
        }
        public void Repos(int x, int y)
        {
            backRec = new Rectangle(x, y, backGround.Width, backGround.Height);
            save.Repos(x,y + backRec.Height + 5);
            cancel.Repos(x + save.mainRec.Width + 10, y + backRec.Height + 5);
            newfolder.Repos(x + (save.mainRec.Width + 10) * 2, y + backRec.Height + 5);
            write.Repos(x, y - 20);
            slider.Resize(x + backGround.Width, y, y + backGround.Height);
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Repos(x + 5,y + 5 + (i * 20));
            }
        }
        public void Update(MouseState mouse, MouseState oldMouse, string savePath, Object input)
        {
            if (savebool == false)
            {
                slider.Update(mouse, oldMouse, buttons.Count - 1);
                if (slider.ChangeButtons(mouse, oldMouse))
                {
                    int move = slider.GetMoveDirection(mouse, oldMouse);
                    for (int i = 0; i < buttons.Count(); i++)
                    {
                        buttons[i].mainRec.Y += move;
                    }
                }
                keyboard = Keyboard.GetState();
                save.Update(mouse, oldMouse);
                cancel.Update(mouse, oldMouse);
                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].Update(mouse, oldMouse);
                    if (buttons[i].pressed == true)
                    {
                        buttons[i].Sound();
                        for (int p = 0; p < buttons.Count; p++)
                        {
                            buttons[p].Clear();
                        }
                        buttons[i].ChangeState();
                        tempname = buttons[i].Text();
                    }
                }
                newfolder.Update(mouse, oldMouse);
                write.Update(keyboard, oldKeyboard);
                saveName = write.GetText();
                if (save.pressed == true && tempname != "" && saveName != "")
                {
                    FileStream fileStream = null;
                    try
                    {
                        fileStream = new FileStream(savePath + "//" + tempname + "//" + saveName, FileMode.Create);
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
                if (newfolder.pressed)
                {
                    savebool = true;
                }
                oldKeyboard = keyboard;

            }
            else
            {
                foldername.Update(mouse, oldMouse, savePath);
                if (foldername.Cancel())
                {
                    savebool = false;
                    buttons = new List<MarkButton>();
                    for (int i = 0; i < Directory.GetDirectories(savePath).Length; i++)
                    {
                        string temp = Directory.GetDirectories(savePath)[i];
                        temp = temp.Replace(savePath + "\\", "");
                        buttons.Add(new MarkButton(button, 3, 1, 207, 225 + (i * 20), temp, clickSound));
                    }
                }
            }

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (savebool == false)
            {
                spriteBatch.Draw(backGround, backRec, Color.White);
                base.Draw(spriteBatch);
                newfolder.Draw(spriteBatch);
                for (int i = slider.DrawFrom(); i < slider.DrawFrom() + slider.GetDrawingLenght(); i++)
                {
                    if (i < buttons.Count)
                    {
                        buttons[i].Draw(spriteBatch);
                        spriteBatch.DrawString(font, buttons[i].Text(), new Vector2(buttons[i].mainRec.X + 20, buttons[i].mainRec.Y), Color.Black,
                        0, new Vector2(0, 0), 0.75f, SpriteEffects.None, 1f);
                    }
                }
                slider.Draw(spriteBatch);
            }
            else
            {
                foldername.Draw(spriteBatch);
            }
        }
    }
}
