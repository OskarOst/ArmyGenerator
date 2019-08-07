using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace ArmyGenerator
{
    class UnitLoad : Load
    {
        private List<Button> buttons;
        private string permanentloadPath;
        private string folder;
        public UnitLoad(Texture2D armyButtons, SpriteFont font, Texture2D markButton, string loadpath, string name, Texture2D decorationPic, int decorationPicNmr, Texture2D button, SoundEffect clickSound, SoundEffect booksound, Texture2D background, int xStart, int yStart, Texture2D mark, Texture2D upDown, int halfwayPoint) : base(armyButtons, font, markButton, loadpath, name, decorationPic, decorationPicNmr, clickSound, booksound, 0, background, xStart, yStart, mark, upDown)
        {
            permanentloadPath = loadpath;
            folder = "";
            buttons = new List<Button>();
            load = new Button(armyButtons, 1, 2, 110, 750, font, "Load Unit", booksound);
            cancel = new Button(armyButtons, 1, 2, 310, 750, font, "Cancel Load", booksound);
            delete = new Button(armyButtons, 1, 2, 510, 750, font, "Delete Unit", booksound);
            for (int i = 0; i < Directory.GetDirectories(loadpath).Length; i++)
            {
                string temp = Directory.GetDirectories(loadpath)[i];
                temp = temp.Replace(loadpath + "\\", "");
                buttons.Add(new Button(button, 1, 2, halfwayPoint + 30, yStart + (50 * i), font, temp, booksound));
            }
        }
        public void Update(MouseState mousestate, MouseState oldmousestate)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Update(mousestate, oldmousestate);
                if (buttons[i].pressed == true)
                {
                    SetButtons(permanentloadPath + "\\" + buttons[i].GetText());
                    folder = buttons[i].GetText();
                }
            }
            base.Update(mousestate, oldmousestate, folder);

        }
        public void Repos(int x, int y, int buttonStart, int buttonPos)
        {
            base.Repos(x, y, buttonStart);
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Repos(buttonPos, y + (buttons[i].height * i)+ (5 * i));
            }
        }
        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            base.Draw(spriteBatch, font);

            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Draw(spriteBatch);
            }
        }
    }
}
