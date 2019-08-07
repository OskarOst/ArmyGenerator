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
    
    class ArmyHandler
    {
        private List<Army> army;
        private List<SwitchArmyButton> switchArmyButton;
        private int selectedArmy;
        private MouseState oldmousestate;
        private SpriteFont font;
        private Texture2D markButton;
        private int positionRegimentEdit;
        private Regiment returnRegiment;
        private Texture2D armyButtons;
        private Texture2D decoration;
        private List<ArmyTextWriter> armytext;
        private Texture2D upDown;
        private Texture2D background;
        private Texture2D mark;
        private Texture2D sortButtons;
        private SoundEffect clickSound;
        private SoundEffect bookSound;
        private int xStart;
        private int yStart;
        private int halfwaypoint;
        private int cuttOff; 
        public ArmyHandler(Texture2D markButton, Texture2D armyButtons, Texture2D soldierRegulateButton, SpriteFont font, string savePath, 
            Texture2D decoration, Texture2D upDown, Texture2D background, Texture2D mark, Texture2D sortButtons, Texture2D magic, 
            Texture2D switchArmy, Texture2D spelllDecoration, SoundEffect bookSound, SoundEffect clickSound, SoundEffect crystalsound, 
            SoundEffect deletesound, Texture2D lineTexture, int xStart, int yStart, float scaledHeigth, float scaledWidth,
            int SwitchArmyButtonsPositionX, int SwitchArmyButtonsPositionY, int SwitchArmyButtonsPositionX2, int halfwaypoint, int cuttOff)
        {
            this.cuttOff = cuttOff;
            this.xStart = xStart;
            this.yStart = yStart;
            this.clickSound = clickSound;
            this.upDown = upDown;
            this.background = background;
            this.mark = mark;
            this.sortButtons = sortButtons;
            this.bookSound = bookSound;
            this.halfwaypoint = halfwaypoint;
            armytext = new List<ArmyTextWriter>();
            armytext.Add(new ArmyTextWriter(upDown, background, mark, sortButtons, font, xStart, yStart, halfwaypoint, armyButtons.Width/2, cuttOff));
            this.decoration = decoration;
            
            selectedArmy = 0;
            this.armyButtons = armyButtons;
            this.markButton = markButton;
            this.font = font;
            army = new List<Army>();
            army.Add(new Army());  
            switchArmyButton = new List<SwitchArmyButton>();
            switchArmyButton.Add(new SwitchArmyButton(switchArmy, 0, SwitchArmyButtonsPositionX, SwitchArmyButtonsPositionY, scaledHeigth, scaledWidth));
            switchArmyButton.Add(new SwitchArmyButton(switchArmy, 1, SwitchArmyButtonsPositionX2, SwitchArmyButtonsPositionY, scaledHeigth, scaledWidth));
            
        }
        public Army GetArmy()
        {
            return army[selectedArmy];
        }
        public void SetArmy(Army input)
        {
            army[selectedArmy] = input;
            armytext[selectedArmy].ClearMarkButtons();

            if (army[selectedArmy] != null)
            {
                for (int i = 0; i < army[selectedArmy].getRegiments().Count; i++)
                {
                    armytext[selectedArmy].AddMarkButton(new MarkButton(markButton, 3, 1, xStart + 5, (yStart + 5 + (20 * i)) + 1, "", clickSound));
                }
            }
        }
        public void Update(MouseState mousestate, string savePath)
        {
            army[selectedArmy].CalculateCost();
            armytext[selectedArmy].Update(mousestate, oldmousestate, army[selectedArmy]);
            returnRegiment = null;
            for (int i = 0; i < switchArmyButton.Count; i++)
            {
                if (i == 0 && selectedArmy > 0)
                {
                    switchArmyButton[i].Update(mousestate, oldmousestate);
                    if (switchArmyButton[i].pressed)
                    {
                        selectedArmy--;
                    }
                }
                if (i == 1 && selectedArmy < army.Count - 1)
                {
                    switchArmyButton[i].Update(mousestate, oldmousestate);
                    if (switchArmyButton[i].pressed)
                    {
                        selectedArmy++;
                    }
                }
            }    
            oldmousestate = mousestate;
        }
        public Regiment GetChosenRegiment()
        {
            Regiment temp = army[selectedArmy].GetRegimentClone(positionRegimentEdit);
            return temp;
        }
        public void AddRegiment(Regiment newRegiment)
        {
            army[selectedArmy].AddRegiment(newRegiment);
            armytext[selectedArmy].AddMarkButton(new MarkButton(markButton, 2, 1, xStart + 5, (yStart + 5 + (20 * (army[selectedArmy].getRegiments().Count - 1))) + 1, "", clickSound));
        }
        public void ClearArmy()
        {
            army[selectedArmy] = new Army();
            armytext[selectedArmy].ClearMarkButtons();
        }
        public void CopyRegiment()
        {
            if (GetArmy().GetRegimentClone(armytext[selectedArmy].GetSelectedMarkButton()) != null)
            {
                AddRegiment(GetArmy().GetRegimentClone(armytext[selectedArmy].GetSelectedMarkButton()));
            }
        }
        public void DeleteRegiment()
        {
            for (int i = 0; i < army[selectedArmy].getRegiments().Count; i++)
            {
                if (armytext[selectedArmy].GetMarkButtons()[i].PressedState())
                {
                    army[selectedArmy].getRegiments().RemoveAt(i);
                    armytext[selectedArmy].EraseMarkButton();
                    armytext[selectedArmy].MarkbuttonsClear(i);
                    army[selectedArmy].CalculateCost();
                    break;
                }
            }
        }
        public void EditRegiment()
        {
            int temp = armytext[selectedArmy].GetSelectedMarkButton();
            if (temp > -1)
            {
                returnRegiment = army[selectedArmy].GetRegimentClone(temp);
                positionRegimentEdit = temp;
                army[selectedArmy].CalculateCost();
            }
        }
        public Regiment GetTempRegiment()
        {
            return returnRegiment;
        }
        public void EditRegiments(Regiment newRegiment)
        {
            army[selectedArmy].EditRegiment(newRegiment, positionRegimentEdit);
        }
        public void AddArmy()
        {
            army.Add(new Army());
            armytext.Add(new ArmyTextWriter(upDown, background, mark, sortButtons, font, xStart, yStart, halfwaypoint, armyButtons.Width / 2, cuttOff));
            selectedArmy = army.Count - 1;
        }
        public void Repos(int xStart, int yStart, float scaledHeigth, float scaledWidth, int SwitchArmyButtonsPositionX, int SwitchArmyButtonsPositionY, 
            int SwitchArmyButtonsPositionX2, int halfWayPosition, int cutOffSize)
        {
            this.xStart = xStart;
            this.yStart = yStart;
            switchArmyButton[0].Rescale(scaledHeigth, scaledWidth, SwitchArmyButtonsPositionX, SwitchArmyButtonsPositionY);
            switchArmyButton[1].Rescale(scaledHeigth, scaledWidth, SwitchArmyButtonsPositionX2, SwitchArmyButtonsPositionY);
            for (int i = 0; i < armytext.Count(); i++)
            {
                armytext[i].Resize(xStart, yStart, halfWayPosition, cutOffSize);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(xStart, yStart, background.Width, background.Height), Color.White);
            for (int i = 0; i < switchArmyButton.Count; i++)
                {
                    if (i == 0 && selectedArmy > 0)
                    {
                        switchArmyButton[i].Draw(spriteBatch);
                    }
                    if (i == 1 && selectedArmy < army.Count - 1)
                    {
                        switchArmyButton[i].Draw(spriteBatch);
                    }
                }
            armytext[selectedArmy].Draw(spriteBatch, army[selectedArmy]);

        }
    }
}
