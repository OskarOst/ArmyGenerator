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
    class ArmyTextWriter
    {
        int x;
        int y;
        int negative;
        int backdraw = 0;
        int halfWayPoint;
        int widthButton; 
        KeyboardState keyboard;
        KeyboardState oldkeyboard;
        Texture2D background;
        List<UpDownButtons> sortButtons;
        SpriteFont font;
        private List<MarkButton> markButtons;
        private SliderClass slider;
        int numberOfUnitsDrawn;
        private int cutOffSize;
        public ArmyTextWriter(Texture2D upDown, Texture2D background, Texture2D mark, Texture2D sortButtonsTexture, SpriteFont font, int x, int y, int halfWayPoint, int buttonwidth, int cutOffSize)
        {
            this.cutOffSize = cutOffSize;
            numberOfUnitsDrawn = 31;
            this.halfWayPoint = halfWayPoint;
            this.widthButton = buttonwidth;
            this.x = x;
            this.y = y;
            negative = 0;
            this.font = font;
            slider = new SliderClass(mark, upDown, 661, numberOfUnitsDrawn, y, x + background.Width - (upDown.Width/4) - 2, y - upDown.Height, y + background.Height, x +background.Width - (mark.Width / 2) - 2, 20);
            sortButtons = new List<UpDownButtons>();
            sortButtons.Add(new UpDownButtons(sortButtonsTexture, 2, 1, x + 639, y, 0));
            sortButtons.Add(new UpDownButtons(sortButtonsTexture, 2, 1, x + 639, y + background.Height - (sortButtonsTexture.Height/2), 1));

            markButtons = new List<MarkButton>();
            this.background = background;
        }
        public void AddMarkButton(MarkButton input)
        {
            markButtons.Add(input);
        }
        public void MarkbuttonsClear(int input)
        {
            if (input < markButtons.Count)
            {
                markButtons[input].Clear();
            }
        }
        public void EraseMarkButton()
        {
            markButtons.RemoveAt(markButtons.Count - 1);
        }
        public List<MarkButton> GetMarkButtons()
        {
            return markButtons;
        }
        public int GetSelectedMarkButton()
        {
            int i = -5;
            for (int p = 0; p < markButtons.Count; p++)
            {
                if (markButtons[p].PressedState())
                {
                    i = p;
                }
            }
            return i;
        }
        public void RemoveMarkButtons()
        {
            markButtons.Clear(); 
        }
        public void Resize(int xStart, int yStart, int halfWayPoint, int cutOffSize)
        {
            this.halfWayPoint = halfWayPoint;
            for (int i = 0; i < markButtons.Count; i++)
            {
                markButtons[i].Reposition(yStart + 5 + i * 20, xStart + 5);
            }
            slider.Resize(xStart + background.Width , yStart, yStart + background.Height);
            sortButtons[0].Repos(xStart + 639, yStart);
            sortButtons[1].Repos(xStart + 639, yStart + background.Height - sortButtons[1].height);
            x = xStart;
            y = yStart;
            this.cutOffSize = cutOffSize;
        }
        public Army Update(MouseState mousestate, MouseState oldmousestate, Army army)
        {
            int count = 0;
            for (int z = 0; z < army.getRegiments().Count; z++)
            {
                count += army.getRegiments()[z].Textsize();
            }
            keyboard = Keyboard.GetState();
            for (int i = 0; i < army.getRegiments().Count; i++)
            {
                if (markButtons[i].mainRec.Y >= y + 5
                        && markButtons[i].mainRec.Y < y + background.Height - 5)
                    markButtons[i].Update(mousestate, oldmousestate);
                if (markButtons[i].pressed == true)
                {
                    markButtons[i].Sound();
                    for (int z = 0; z < markButtons.Count(); z++)
                    {
                        markButtons[z].Clear();
                    }
                    markButtons[i].ChangeState();
                }

            }
            int p = 0;
            for (int i = 0; i < markButtons.Count; i++)
            {
                if (markButtons[i].PressedState())
                {
                    p = i;
                }
            }
            for (int i = 0; i < sortButtons.Count; i++)
            {
                sortButtons[i].Update(mousestate, oldmousestate);
            }
            Regiment tempReg;
            if (sortButtons[0].pressed && p != 0)
            {
                tempReg = army.getRegiments()[p];
                army.SortRegiments(tempReg, p, -1, markButtons.Count() - 1);
                for (int z = 0; z < markButtons.Count(); z++)
                {
                    markButtons[z].Clear();
                }
                markButtons[p - 1].ChangeState();
            }
            else if (sortButtons[1].pressed && p != 0)
            {
                tempReg = army.getRegiments()[p];
                army.SortRegiments(tempReg, p, 1, markButtons.Count() - 1);
                for (int z = 0; z < markButtons.Count(); z++)
                {
                    markButtons[z].Clear();
                }
                markButtons[p + 1].ChangeState();
            }
            int d = 0;
            for (int i = 0; i < army.getRegiments().Count; i++)
            {
                d += army.getRegiments()[i].Textsize();
            }
            slider.Update(mousestate, oldmousestate, army.getRegiments().Count - 1);
            if (slider.ChangeButtons(mousestate, oldmousestate))
            {
                int move = slider.GetMoveDirection(mousestate, oldmousestate);
                for (int i = 0; i < markButtons.Count(); i++)
                {
                    markButtons[i].mainRec.Y += move;
                }
            }
            negative = slider.Negative();
            oldkeyboard = keyboard;
            return army;
        }
        public int Calculate(int count)
        {
            if (count < 1)
                count = 1;
            int positions = 600 / count;
            List<int> pos = new List<int>();
            for (int i = 0; i < count; i++)
            {
                pos.Add(positions * i);
            }
            return 90 + backdraw * positions;
        }
        public void ClearMarkButtons()
        {
            markButtons = new List<MarkButton>();
        }
        public void Draw(SpriteBatch spriteBatch, Army army)
        {
            slider.Draw(spriteBatch);
            for (int i = 0; i < sortButtons.Count; i++)
            {
                sortButtons[i].Draw(spriteBatch);
            }
            for (int i = slider.DrawFrom(); i <= slider.DrawFrom() + slider.GetDrawingLenght(); i++)
            {
                if (i < markButtons.Count)
                {
                    markButtons[i].Draw(spriteBatch);
                    spriteBatch.DrawString(font, army.getRegiments()[i].GetText(font), new Vector2(markButtons[i].mainRec.X + 20, markButtons[i].mainRec.Y), Color.Black, 0, new Vector2(0, 0), 0.75f, SpriteEffects.None, 1f);
                }
            }
            spriteBatch.DrawString(font, ("Total army cost: " + army.GetTotalCost().ToString() + " PTS"), new Vector2(220, 50), Color.Black,
                    0, new Vector2(0, 0), 0.75f, SpriteEffects.None, 1f);
            spriteBatch.DrawString(font, ("Number of Slots: " + army.GetNumberOfSlots().ToString()), new Vector2(220, 70), Color.Black,
            0, new Vector2(0, 0), 0.75f, SpriteEffects.None, 1f);
            spriteBatch.DrawString(font, ("Number of Miniatures: " + army.GetNumberOfSoldiers()), new Vector2(220, 90), Color.Black,
            0, new Vector2(0, 0), 0.75f, SpriteEffects.None, 1f);
            if(GetSelectedMarkButton() >= 0)
            {
                int selectedRegiment = GetSelectedMarkButton();
                string unittext = army.getRegiments()[selectedRegiment].GetFullText(font, cutOffSize - halfWayPoint);
                spriteBatch.DrawString(font, unittext, new Vector2(halfWayPoint + widthButton + 50, 100), Color.Black,
                0, new Vector2(0, 0), 0.75f, SpriteEffects.None, 1f);
            }
        }
    }
}
