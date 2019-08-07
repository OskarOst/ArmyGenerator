using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Xna.Framework.Audio;

namespace ArmyGenerator
{
    class Load
    {
        public Button load;
        public Button cancel;
        private SliderClass slider;
        public Button delete;
        private Texture2D markButton;
        private List<MarkButton> markbuttons;
        private string loadName;
        private string loadpath;
        private int offsett;
        private string[] files;
        private Object returnObject;
        private string name;
        private Texture2D decorationPic;
        //private Decoration Decoration;
        SoundEffect clickSound;
        private int xStart;
        private int yStart;
        private Texture2D backGround;
        private Rectangle backRec;
        public Load(Texture2D armyButtons, SpriteFont font, Texture2D markButton, string loadpath, string name, Texture2D decorationPic, int decorationPicNmr,
            SoundEffect clickSound, SoundEffect bookSound, int buttonStart, Texture2D backGround, int xStart, int yStart, Texture2D mark, Texture2D upDown)
        {
            slider = new SliderClass(mark, upDown, 661, 31, yStart, xStart + backGround.Width - (upDown.Width / 4) - 2, yStart - upDown.Height, yStart + backGround.Height, xStart + backGround.Width - (mark.Width / 2) - 2, 20);
            this.backGround = backGround;
            this.xStart = xStart;
            this.yStart = yStart;
            backRec = new Rectangle(xStart, yStart, backGround.Width, backGround.Height);
            this.clickSound = clickSound;
            this.markButton = markButton;
            //Decoration = new Decoration(decorationPic, 1, 4, 925, 0, decorationPicNmr);
            this.decorationPic = decorationPic;
            this.name = name;
            this.loadpath = loadpath;
            markbuttons = new List<MarkButton>();
            files = Directory.GetFiles(loadpath);
            for (int i = 0; i < files.Length; i++)
            {
                markbuttons.Add(new MarkButton(markButton, 3, 1, xStart + 10, yStart + 15 + (20 * i) + 1, "", clickSound));
                files[i] = files[i].Replace(loadpath + "\\", "");
                offsett++;
            }
            int buttonOffset = 0;
            load = new Button(armyButtons, 1, 2, xStart + (200 * buttonOffset), buttonStart, font, "Load " + name,bookSound);
            buttonOffset++;
            cancel = new Button(armyButtons, 1, 2, xStart + (200 * buttonOffset), buttonStart, font, "Cancel", bookSound);
            buttonOffset++;
            delete = new Button(armyButtons, 1, 2, xStart + (200 * buttonOffset), buttonStart, font, "Delete " + name, bookSound);
            loadName = "";
        }
        public void SetButtons(string newLoadPath)
        {
            markbuttons = new List<MarkButton>();
            files = Directory.GetFiles(newLoadPath);
            for (int i = 0; i < files.Length; i++)
            {
                markbuttons.Add(new MarkButton(markButton, 3, 1, xStart + 10, yStart + 15 + (20 * i) + 1, "", clickSound));
                files[i] = files[i].Replace(newLoadPath + "\\", "");
                offsett++;
            }
            loadName = "";
        }
        public virtual void Repos(int x, int y, int buttonStart)
        {
            int p;
            backRec = new Rectangle(x,y, backGround.Width, backGround.Height);
            slider.Resize(x + backGround.Width, y, y + backGround.Height);
            xStart = x;
            yStart = y;
            int buttonOffset = 0; 
            load.Repos(x + (200 * buttonOffset), y + backRec.Height + 5);
            buttonOffset++;
            cancel.Repos(x + (200 * buttonOffset), y + backRec.Height + 5);
            buttonOffset++;
            delete.Repos(x + (200 * buttonOffset), y + backRec.Height + 5);
            for (int i = 0; i < markbuttons.Count; i++)
            {
                markbuttons[i].Reposition(yStart + 5 + i * 20, xStart + 5);
            }
        }
        public void Update(MouseState mouse, MouseState oldMouse)
        {
            load.Update(mouse, oldMouse);
            cancel.Update(mouse, oldMouse);
            delete.Update(mouse, oldMouse);
            slider.Update(mouse, oldMouse, markbuttons.Count- 1);
            if (slider.ChangeButtons(mouse, oldMouse))
            {
                int move = slider.GetMoveDirection(mouse, oldMouse);
                for (int i = 0; i < markbuttons.Count(); i++)
                {
                    markbuttons[i].mainRec.Y += move;
                }
            }
            for (int i = 0; i < markbuttons.Count; i++)
            {
                markbuttons[i].Update(mouse, oldMouse);
                if (markbuttons[i].pressed == true)
                {
                    markbuttons[i].Sound();
                    for (int p = 0; p < markbuttons.Count; p++)
                    {
                        markbuttons[p].Clear();
                    }
                    markbuttons[i].ChangeState();
                    loadName = files[i];
                }
            }
            if (load.pressed)
            {
                FileStream filestream = null;
                try
                {
                    if (File.Exists(loadpath + "//" + loadName))
                    {
                        filestream = new FileStream(loadpath + "//" + loadName, FileMode.Open);
                        BinaryFormatter b = new BinaryFormatter();
                        returnObject = b.Deserialize(filestream);
                    }
                }
                finally
                {
                    if (filestream != null)
                        filestream.Close();
                }
            }
            else if (delete.pressed && loadName != "")
            {
                File.Delete(loadpath + "//" + loadName);
                files = Directory.GetFiles(loadpath);
                for (int i = 0; i < files.Length; i++)
                {
                    files[i] = files[i].Replace(loadpath + "\\", "");
                    offsett++;
                }
            }
        }
        public void Update(MouseState mouse, MouseState oldMouse, string name)
        {
            load.Update(mouse, oldMouse);
            cancel.Update(mouse, oldMouse);
            delete.Update(mouse, oldMouse);
            slider.Update(mouse, oldMouse, 0);
            for (int i = 0; i < markbuttons.Count; i++)
            {
                markbuttons[i].Update(mouse, oldMouse);
                if (markbuttons[i].pressed == true)
                {
                    markbuttons[i].Sound();
                    for (int p = 0; p < markbuttons.Count; p++)
                    {
                        markbuttons[p].Clear();
                    }
                    markbuttons[i].ChangeState();
                    loadName = files[i];
                }
            }
            if (load.pressed)
            {
                FileStream filestream = null;
                try
                {
                    if (File.Exists(loadpath + "//" + name + "//" + loadName))
                    {
                        filestream = new FileStream(loadpath + "//" + name + "//" + loadName, FileMode.Open);
                        BinaryFormatter b = new BinaryFormatter();
                        returnObject = b.Deserialize(filestream);
                    }
                }
                finally
                {
                    if (filestream != null)
                        filestream.Close();
                }
            }
            else if (delete.pressed && loadName != "")
            {
                string tempName = "";
                if(name != "")
                {
                    tempName = "\\" + name;
                }
                File.Delete(loadpath + tempName + "//" + loadName);
                files = Directory.GetFiles(loadpath);
                for (int i = 0; i < files.Length; i++)
                {
                    files[i] = files[i].Replace(loadpath + "\\", "");
                    offsett++;
                }
            }
        }
        public string LoadName()
        {
            return loadName;
        }
        public Object ReturnObject()
        {
            return returnObject;
        }
        public bool Loaded()
        {
            if (load.pressed == true)
            {
                return true;
            }
            return false;
        }
        public bool Cancel()
        {
            if (cancel.pressed == true)
            {
                return true;
            }
            return false;
        }
        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.Draw(backGround, backRec, Color.White);
            slider.Draw(spriteBatch);
            load.Draw(spriteBatch);
            cancel.Draw(spriteBatch);
            delete.Draw(spriteBatch);
            for (int i = slider.DrawFrom(); i <= slider.DrawFrom() + slider.GetDrawingLenght(); i++)
            {
                if (i < markbuttons.Count)
                {
                    markbuttons[i].Draw(spriteBatch);
                    spriteBatch.DrawString(font, files[i], new Vector2(markbuttons[i].mainRec.X + 20, markbuttons[i].mainRec.Y), Color.Black, 0, new Vector2(0, 0), 0.75f, SpriteEffects.None, 1f);
                }
            }

        }
    }
}
