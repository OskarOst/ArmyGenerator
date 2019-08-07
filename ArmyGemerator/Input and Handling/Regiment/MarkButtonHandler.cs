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
    class MarkButtonHandler
    {
        List<List<EquipmentMarkButton>> buttonsList;
        SoundEffect clickSound;
        Texture2D markButton;
        private Equipment output;
        private Parchment parchment;
        List<int> numberlist;
        private int numberOfLines; 
        private Vector2 PressedButton;
        private int offsetBetweenButtons;
        private int widthBetweenButtons;
        private int startPos;
        SpriteFont font;

        public MarkButtonHandler(Texture2D markButton, Texture2D show, SoundEffect horseSound, SoundEffect clickSound, SoundEffect swordSound, SoundEffect arrowSound, Vector2 screenSize, SpriteFont font, int buttonPosition,
            int cutoff, int buttonPos2, int markButtonStartPos)
        {
            this.font = font;
            this.clickSound = clickSound;
            this.markButton = markButton;
            parchment = new Parchment(show, screenSize, font);
            buttonsList = new List<List<EquipmentMarkButton>>();
            string tempname = "";
            numberlist = new List<int>();
            numberlist.Add(0);
            numberlist.Add(0);
            numberlist.Add(0);
            Equipment equipmentinput = new Equipment();
            int p = 0;
            int yoff = 1;
            offsetBetweenButtons = 20;
            startPos = markButtonStartPos;
            widthBetweenButtons = 185;
            for (int i = 0; i < 9; i++)
            {
                buttonsList.Add(new List<EquipmentMarkButton>());
            }
            SoundEffect tempSound = swordSound;
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                {
                    equipmentinput = new SideArm();
                }
                else if (i == 1)
                {
                    equipmentinput = new Longsword();
                }
                else if (i == 2)
                {
                    equipmentinput = new Warhammer();
                }
                else if (i == 3)
                {
                    equipmentinput = new Shield();
                }
                else if (i == 4)
                {
                    equipmentinput = new DualWieldedWeapon();
                }
                else if (i == 5)
                {
                    equipmentinput = new Polearm();
                }
                else if (i == 6)
                {
                    equipmentinput = new Spear();
                }
                else if (i == 7)
                {
                    equipmentinput = new Pike();
                }
                else if (i == 8)
                {
                    equipmentinput = new Pavise();
                }
                else if (i == 9)
                {
                    equipmentinput = new Lance();
                }
                tempname = equipmentinput.GetName() + "/ " + equipmentinput.Cost() + "pts";
                if (buttonPos2 + (widthBetweenButtons * p) + 20 + (font.MeasureString(tempname).X * 0.75f) > cutoff)
                {
                    p = 0;
                    yoff++;
                }
                buttonsList[0].Add(new EquipmentMarkButton(equipmentinput, markButton, 3, 1, buttonPos2 + (widthBetweenButtons * p), startPos + (offsetBetweenButtons * yoff), tempname, tempSound, 0.5f));
                p++;
            }
            tempSound = clickSound;
            buttonsList[0][0].ChangeState();
            yoff ++;
            p = 0;
            yoff++;
            for (int i = 0; i < 7; i++)
            {
                if (i == 0)
                {
                    equipmentinput = new UnArmoured();
                }
                else if (i == 1)
                {
                    equipmentinput = new SparseArmour();
                }
                else if (i == 2)
                {
                    equipmentinput = new CoveringArmour();
                }
                else if (i == 3)
                {
                    equipmentinput = new FullPlateArmour();
                }
                else if (i == 4)
                {
                    tempSound = horseSound;
                    equipmentinput = new PartialHorseArmour();
                }
                else if (i == 5)
                {
                    tempSound = horseSound;
                    equipmentinput = new HeavyHorseArmour();
                }
                else if (i == 6)
                {
                    tempSound = horseSound;
                    equipmentinput = new CoveringPlateHorseArmour();
                }
                tempname = equipmentinput.GetName() + "/ " + equipmentinput.Cost() + "pts";
                if (buttonPos2 + (widthBetweenButtons * p) + 20 + (font.MeasureString(tempname).X * 0.75f) > cutoff)
                {
                    p = 0;
                    yoff++;
                }
                buttonsList[1].Add(new EquipmentMarkButton(equipmentinput, markButton, 3, 1, buttonPos2 + (widthBetweenButtons * p), startPos + (offsetBetweenButtons * yoff), tempname, tempSound, 0.5f));
                p++;
            }
            tempSound = arrowSound;
            buttonsList[1][0].ChangeState();
            yoff += 2;
            p = 0;
            for (int i = 0; i < 9; i++)
            {
                if (i == 0)
                {
                    equipmentinput = new GoodOldFists();
                }
                else if (i == 1)
                {
                    equipmentinput = new Sling();
                }
                else if (i == 2)
                {
                    equipmentinput = new Shortbow();
                }
                else if (i == 3)
                {
                    equipmentinput = new Longbow();
                }
                else if (i == 4)
                {
                    equipmentinput = new LightCrossbow();
                }
                else if (i == 5)
                {
                    equipmentinput = new HeavyCrossbow();
                }
                else if (i == 6)
                {
                    equipmentinput = new Handgonne();
                }
                else if (i == 7)
                {
                    equipmentinput = new ThrowingWeapon();
                }
                else if (i == 8)
                {
                    equipmentinput = new Pistol();
                }
                tempname = equipmentinput.GetName() + "/ " + equipmentinput.Cost() + "pts";
                tempname = equipmentinput.GetName() + "/ " + equipmentinput.Cost() + "pts";
                if (buttonPos2 + (widthBetweenButtons * p) + 20 + (font.MeasureString(tempname).X * 0.75f) > cutoff)
                {
                    p = 0;
                    yoff++;
                }
                buttonsList[2].Add(new EquipmentMarkButton(equipmentinput, markButton, 3, 1, buttonPos2 + (widthBetweenButtons * p), startPos + (offsetBetweenButtons * yoff), tempname, tempSound, 0.5f));
                p++;
            }
            tempSound = horseSound;
            p = 0;
            yoff += 2;
            buttonsList[2][0].ChangeState();
            for (int i = 0; i < 7; i++)
            {
                if (i == 0)
                {
                    equipmentinput = new Feet();
                }
                else if (i == 1)
                {
                    equipmentinput = new Courser();
                }
                else if (i == 2)
                {
                    equipmentinput = new Charger();
                }
                else if (i == 3)
                {
                    equipmentinput = new Flyer();
                }
                else if (i == 4)
                {
                    equipmentinput = new MonsterousMount();
                }
                else if (i == 5)
                {
                    equipmentinput = new LightChariot();
                }
                else if (i == 6)
                {
                    equipmentinput = new HeavyChariot();
                }
                tempname = equipmentinput.GetName() + "/ " + equipmentinput.Cost() + "pts";
                if (buttonPos2 + (widthBetweenButtons * p) + 20 + (font.MeasureString(tempname).X * 0.75f) > cutoff)
                {
                    p = 0;
                    yoff++;
                }
                buttonsList[3].Add(new EquipmentMarkButton(equipmentinput, markButton, 3, 1, buttonPos2 + (widthBetweenButtons * p), startPos + (offsetBetweenButtons * yoff), tempname, tempSound, 0.5f));
                p++;
            }
            buttonsList[3][0].ChangeState();
            p = 0;
            yoff += 2;
            int posVeteran = yoff;
            tempSound = clickSound;
            for (int i = 0; i < 12; i++)
            {
                if (i == 0)
                {
                    equipmentinput = new GenericVeteran();
                }
                else if (i == 1)
                {
                    equipmentinput = new Skirmishers();
                }
                else if (i == 2)
                {
                    equipmentinput = new Rangers();
                }
                else if (i == 3)
                {
                    equipmentinput = new Commandos();
                }
                else if (i == 4)
                {
                    equipmentinput = new Zombify();
                }
                else if (i == 5)
                {
                    equipmentinput = new Possessed();
                }
                else if (i == 6)
                {
                    equipmentinput = new Fire_Arrows();
                }
                else if (i == 7)
                {
                    equipmentinput = new Winged();
                }
                else if (i == 8)
                {
                    equipmentinput = new Reckless();
                }
                else if (i == 9)
                {
                    equipmentinput = new MagicallyCharged();
                }
                else if (i == 10)
                {
                    equipmentinput = new Diciples();
                }
                else if (i == 11)
                {
                    equipmentinput = new SavageFighters();
                }
                tempname = equipmentinput.GetName() + "/ " + equipmentinput.Cost() + "pts";
                if (buttonPos2 + (widthBetweenButtons * p) + 20 + (font.MeasureString(tempname).X * 0.75f) > cutoff)
                {
                    p = 0;
                    yoff++;
                }
                buttonsList[4].Add(new EquipmentMarkButton(equipmentinput, markButton, 3, 1, buttonPos2 + (widthBetweenButtons * p), startPos + (offsetBetweenButtons * yoff), tempname, tempSound, 0.5f));
                p++;
            }
            buttonsList[4][0].ChangeState();
            yoff += 2;
            p = 0;
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    equipmentinput = new NoFortifications();
                }
                else if (i == 1)
                {
                    equipmentinput = new SharpenedStakes();
                }
                else if (i == 2)
                {
                    equipmentinput = new WarWagon();
                }
                else if (i == 3)
                {
                    equipmentinput = new Mantles();
                }
                tempname = equipmentinput.GetName() + "/ " + equipmentinput.Cost() + "pts";
                if (buttonPos2 + (widthBetweenButtons * p) + 20 + (font.MeasureString(tempname).X * 0.75f) > cutoff)
                {
                    p = 0;
                    yoff++;
                }
                buttonsList[5].Add(new EquipmentMarkButton(equipmentinput, markButton, 3, 1, buttonPos2 + (widthBetweenButtons * p), startPos + (offsetBetweenButtons * yoff), tempname, tempSound, 0.5f));
                p++;
            }
            numberOfLines = yoff + 2;
            buttonsList[5][0].ChangeState();
            p = 0;
            yoff = posVeteran;
            for (int i = 0; i < 7; i++)
            {
                if (i == 0)
                {
                    equipmentinput = new NoArtillery();
                }
                else if (i == 1)
                {
                    equipmentinput = new Balista();
                }
                else if (i == 2)
                {
                    equipmentinput = new LightCatapult();
                }
                else if (i == 3)
                {
                    equipmentinput = new HeavyCatapult();
                }
                else if (i == 4)
                {
                    equipmentinput = new Cannon();
                }
                else if (i == 5)
                {
                    equipmentinput = new RibaultGun();
                }
                else if (i == 6)
                {
                    equipmentinput = new FlameThrower();
                }
                tempname = equipmentinput.GetName() + "/ " + equipmentinput.Cost() + "pts";
                if (buttonPos2 + (widthBetweenButtons * p) + 20 + (font.MeasureString(tempname).X * 0.75f) > cutoff)
                {
                    p = 0;
                    yoff++;
                }
                buttonsList[6].Add(new EquipmentMarkButton(equipmentinput, markButton, 3, 1, buttonPos2 + (widthBetweenButtons * p), startPos + (offsetBetweenButtons * yoff), tempname, tempSound, 0.5f));
                p++;
            }
            yoff = posVeteran;
            p = 0;
            for (int i = 0; i < 9; i++)
            {
                if (i == 0)
                {
                    equipmentinput = new GenericHero();
                }
                else if (i == 1)
                {
                    equipmentinput = new GreatWarrior();
                }
                else if (i == 2)
                {
                    equipmentinput = new EagleEyed();
                }
                else if (i == 3)
                {
                    equipmentinput = new InspiringLeader();
                }
                else if (i == 4)
                {
                    equipmentinput = new TrueHero();
                }
                else if (i == 5)
                {
                    equipmentinput = new Conjurer();
                }
                else if (i == 6)
                {
                    equipmentinput = new Enchanter();
                }
                else if (i == 7)
                {
                    equipmentinput = new ArmyStandard();
                }
                else if (i == 8)
                {
                    equipmentinput = new Dragonslayer();
                }
                tempname = equipmentinput.GetName() + "/ " + equipmentinput.Cost() + "pts";
                if (buttonPos2 + (widthBetweenButtons * p) + 20 + (font.MeasureString(tempname).X * 0.75f) > cutoff)
                {
                    p = 0;
                    yoff++;
                }
                buttonsList[7].Add(new EquipmentMarkButton(equipmentinput, markButton, 3, 1, buttonPos2 + (widthBetweenButtons * p), startPos + (offsetBetweenButtons * yoff), tempname, tempSound, 0.5f));
                p++;
            }
            buttonsList[7][0].ChangeState();
            buttonsList[6][0].ChangeState();
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    equipmentinput = new UnitLeader();
                }
                else if (i == 1)
                {
                    equipmentinput = new Muscicians();
                }
                else if (i == 2)
                {
                    equipmentinput = new BannerBearer();
                }
                else if (i == 3)
                {
                    equipmentinput = new BannerBearer();
                }
                tempname = equipmentinput.GetName() + "/ " + equipmentinput.Cost() + "pts";
                buttonsList[8].Add(new EquipmentMarkButton(equipmentinput, markButton, 3, 1, 120 + (170 * i), buttonPosition - 30, tempname, tempSound));
            }
        }
        public bool Update(MouseState mouseState, MouseState oldMouseState, BaseUnit soldiertype)
        {
            Rectangle mouseRec = new Rectangle(mouseState.X, mouseState.Y, 1, 1);
            for (int i = 0; i < buttonsList.Count(); i++)
            {

                for (int y = 0; y < buttonsList[i].Count(); y++)
                {
                    if (UpdateOnlyWhenRightType(soldiertype, i, y))
                    {
                        buttonsList[i][y].Update(mouseState, oldMouseState);
                        if (buttonsList[i][y].pressed)
                        {
                            PressedButton.X = i;
                            PressedButton.Y = y;
                            if (buttonsList[i][y].IsTurnedOff())// temp
                            {
                                return false;
                            }
                            else
                            {
                                buttonsList[i][y].Sound();
                                output = buttonsList[i][y].GetEquipment();
                                return true;
                            }
                        }
                        else if (buttonsList[i][y].MouseIntersect(mouseRec))
                        {
                            if (parchment.Countdown())
                            {
                                parchment.Create(mouseRec.X, mouseRec.Y, buttonsList[i][y].GetEquipment());
                            }
                        }
                    }
                }
            }
            if (parchment.Exist() && !parchment.Interact(mouseRec))
            {
                parchment.Reset();
            }
            return false;
        }
        public bool RemoveItem()
        {
            if (buttonsList[(int)PressedButton.X][(int)PressedButton.Y].state == State.On)
            {
                return true;
            }
            return false;
        }
        public void UpdateShow(List<Equipment> input, BaseUnit soldiertype)
        {
            for (int i = 0; i < buttonsList.Count(); i++)
            {
                for (int y = 0; y < buttonsList[i].Count(); y++)
                {
                    buttonsList[i][y].Clear();
                    for (int p = 0; p < input.Count(); p++)
                    {
                        if (input[p] != null)
                        {
                            if (input[p].GetName() == buttonsList[i][y].GetEquipment().GetName())
                            {
                                buttonsList[i][y].turnOn();
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < buttonsList.Count(); i++)
            {
                for (int y = 0; y < buttonsList[i].Count(); y++)
                {
                    if (TurnOffShowTest(i,y, soldiertype))
                    {
                        buttonsList[i][y].TurnOffShow();
                    }
                }
            }
        }
        private bool TurnOffShowTest(int i, int y, BaseUnit soldiertype)
        {
            if (i == 1)
            {
                int p = 0;
            }
            if (buttonsList[i][y].IsTurnedOn())
            {
                return false;
            }
            if (!(i == 4 && y == 0) && buttonsList[4][4].IsTurnedOn())
            {
                return true;
            }
            else if (((i == 0 && (y == 4 || y == 5 || y == 6 || y == 7 || y == 8)) && !(buttonsList[3][0].IsTurnedOn() || soldiertype is BaseCentaur))) //cannot get infantry only weapons if mounted
            {
                return true;
            }
            // Cannot buy lances unless mounted or centaur
            else if ((i == 0 && y == 9) && (buttonsList[3][0].IsTurnedOn() && !(soldiertype is BaseCentaur)))
            {
                return true;
            }
            //Cannot buy mount if has infantry weapon)
            else if (((i == 3 && (y == 1 || y == 2 || y == 3 || y == 4 || y == 5 || y == 6)) && (buttonsList[0][4].IsTurnedOn() || buttonsList[0][5].IsTurnedOn() || buttonsList[0][6].IsTurnedOn() || buttonsList[0][7].IsTurnedOn() || buttonsList[0][8].IsTurnedOn())))
            {
                return true;
            }
            //Cannot buy Horses if in infantry armour
            else if (((i == 3 && y != 0) && ((buttonsList[1][1].IsTurnedOn() || buttonsList[1][2].IsTurnedOn() || buttonsList[1][3].IsTurnedOn()) || soldiertype is BaseCentaur)))
            {
                return true;
            }
            //Cannot buy horse armour if on foot
            else if ((i == 1 && y > 3) && buttonsList[3][0].IsTurnedOn() && !(soldiertype is BaseCentaur))
            {
                return true;
            }
            //Cannot buy infantry armour if mounted
            else if ((i == 1 && (y == 1 || y == 2 || y == 3)) && !buttonsList[3][0].IsTurnedOn())
            {
                return true;
            }
            //Cannot buy skirmisher in heavy armour
            else if ((i == 4 && (y == 1 || y == 2 || y == 3)) && (buttonsList[1][2].IsTurnedOn() || buttonsList[1][3].IsTurnedOn() || buttonsList[1][5].IsTurnedOn() || buttonsList[1][6].IsTurnedOn()))
            {
                return true;
            }
            // Cannot buy heavy armour if Skirmisher
            else if ((i == 1 && (y == 2 || y == 3 || y == 5 || y == 6)) && (buttonsList[4][1].IsTurnedOn() || buttonsList[4][3].IsTurnedOn() || buttonsList[4][2].IsTurnedOn()))
            {
                return true;
            }
            else if (i == 4 && y == 6 && !(buttonsList[2][2].IsTurnedOn() || buttonsList[2][3].IsTurnedOn()))
            {
                return true;
            }
            else if (i == 5 && y == 3 && !(soldiertype is Artilleryman))
            {
                return true;
            }
            return false;
        }
        public void ResizeWindows(int buttonPos2, int cutoff, int markButtonStartPos,int unitUpdatesPos)
        {
            startPos = markButtonStartPos;
            int xOff = 0;
            int yOff = 0;
            int sety = 0;
            for (int i = 0; i < buttonsList.Count; i++)
            {
                if (i != 8)
                {
                    if (i == 4)
                    {
                        sety = yOff;
                    }
                    else if (i == 6|| i == 7)
                    {
                        yOff = sety;
                    }
                    for (int z = 0; z < buttonsList[i].Count; z++)
                    {
                        if (buttonPos2 + (widthBetweenButtons * xOff) + (20 * xOff) + (font.MeasureString(buttonsList[i][z].Text()).X * 0.75f) > cutoff)
                        {
                            xOff = 0;
                            yOff++;
                        }
                        buttonsList[i][z].Repos(buttonPos2 + (widthBetweenButtons * xOff), markButtonStartPos + (offsetBetweenButtons * yOff));
                        xOff++;

                    }
                    if (i == 5)
                    {
                        numberOfLines = yOff + 2;
                    }
                    yOff += 2;
                    xOff = 0;
                }
            }
            for (int i = 0; i < buttonsList[8].Count; i++)
            {
                buttonsList[8][i].Repos(110 + widthBetweenButtons * i, unitUpdatesPos);
            }
        }
        public int NumberOfLines()
        {
            return (numberOfLines * offsetBetweenButtons) + startPos;
        }
        public void Draw(SpriteBatch spritebatch, SpriteFont font, BaseUnit soldiertype)
        {
            int heroPointsCost = 1;
            for (int i = 1; i < buttonsList[7].Count; i++)
            {
                if (buttonsList[7][i].IsTurnedOn())
                {
                    heroPointsCost++;
                }
            }
            for (int i = 0; i < buttonsList.Count; i++)
            {
                for (int y = 0; y < buttonsList[i].Count; y++)
                {
                    if (UpdateOnlyWhenRightType(soldiertype, i, y))
                    {
                        buttonsList[i][y].Draw(spritebatch);
                        if (i == 7 && y > 0)
                        {
                            spritebatch.DrawString(font, buttonsList[i][y].Text(heroPointsCost), new Vector2(buttonsList[i][y].mainRec.X + 20, buttonsList[i][y].mainRec.Y), Color.Black, 0,
                            new Vector2(0, 0), 0.75f, SpriteEffects.None, 1f);
                        }
                        else
                        {
                            spritebatch.DrawString(font, buttonsList[i][y].Text(), new Vector2(buttonsList[i][y].mainRec.X + 20, buttonsList[i][y].mainRec.Y), Color.Black, 0,
                            new Vector2(0, 0), 0.75f, SpriteEffects.None, 1f);
                        }
                    }
                }
            }
            parchment.Draw(spritebatch, font);
        }
        public Equipment GetEquipment()
        {
            return output;
        }
        public bool UpdateOnlyWhenRightType(BaseUnit soldiertype, int i, int y)
        {
            if(soldiertype != null)
                return soldiertype.CanAddItem(buttonsList[i][y].GetEquipment());
            return false;
        }
        public Equipment RemoveEquipment()
        {
            for (int i = 0; i < buttonsList.Count; i++)
            {
                for (int y = 0; y < buttonsList[i].Count; y++)
                {
                    if (buttonsList[i][y].pressed)
                    {
                        return buttonsList[i][y].GetEquipment();
                    }
                }
            }
            return null;
        }
        public void CheckCanSee(BaseUnit soldiertype)
        {
            for (int i = 0; i < buttonsList.Count; i++)
            {
                for (int y = 0; y < buttonsList[i].Count; y++)
                {
                    if (buttonsList[i][y].currentFrame == 2)
                    {
                        buttonsList[i][y].TurnOnShow();
                    }
                }
            }
            if (!(soldiertype is Artilleryman))
            {
                buttonsList[5][3].TurnOffShow();
            }
            if (!buttonsList[3][0].IsTurnedOn())
            {
                //Cannot buy infantry weapons if mounted
                buttonsList[0][4].TurnOffShow();
                buttonsList[0][5].TurnOffShow();
                buttonsList[0][6].TurnOffShow();
                buttonsList[0][7].TurnOffShow();
                buttonsList[0][8].TurnOffShow();
                buttonsList[1][1].TurnOffShow();
                buttonsList[1][2].TurnOffShow();
                buttonsList[1][3].TurnOffShow();
            }
            if (buttonsList[0][4].IsTurnedOn() || buttonsList[0][5].IsTurnedOn() || buttonsList[0][6].IsTurnedOn() || buttonsList[0][7].IsTurnedOn() || buttonsList[0][8].IsTurnedOn())
            {
                //Cannot buy mount if infantry weapons
                buttonsList[3][1].TurnOffShow();
                buttonsList[3][2].TurnOffShow();
                buttonsList[3][3].TurnOffShow();
                buttonsList[3][4].TurnOffShow();
                buttonsList[3][5].TurnOffShow();
                buttonsList[3][6].TurnOffShow();

            }
            if (buttonsList[3][0].IsTurnedOn() && !(soldiertype is BaseCentaur))
            {
                //Cannot get Lance or horse armour if not mounted
                buttonsList[0][9].TurnOffShow();
                buttonsList[1][4].TurnOffShow();
                buttonsList[1][5].TurnOffShow();
                buttonsList[1][6].TurnOffShow();
            }
            if (!buttonsList[3][0].IsTurnedOn() || soldiertype is BaseCentaur)
            {
                //Cannot get foot armour if mounted or centaur
                buttonsList[1][1].TurnOffShow();
                buttonsList[1][2].TurnOffShow();
                buttonsList[1][3].TurnOffShow();
            }
            if (buttonsList[4][4].IsTurnedOn())
            {
                //Cannot buy stuff if zombie
                for (int i = 0; i < buttonsList.Count; i++)
                {
                    for (int y = 1; y < buttonsList[i].Count; y++)
                    {
                        if (i != 4)
                        {
                            buttonsList[i][y].TurnOffShow();
                        }
                    }
                }
            }
            if ((buttonsList[0][1].IsTurnedOn() || buttonsList[0][2].IsTurnedOn() || buttonsList[0][3].IsTurnedOn() || buttonsList[0][4].IsTurnedOn() || buttonsList[0][5].IsTurnedOn() || buttonsList[0][6].IsTurnedOn() || buttonsList[0][7].IsTurnedOn() || buttonsList[0][8].IsTurnedOn() || buttonsList[0][9].IsTurnedOn()) || !buttonsList[1][0].IsTurnedOn() || !buttonsList[2][0].IsTurnedOn() || !buttonsList[3][0].IsTurnedOn() || !buttonsList[5][0].IsTurnedOn())
            {
                //Cannot buy zombie if has stuff
                buttonsList[4][4].TurnOffShow();
            }
            if (buttonsList[1][2].IsTurnedOn() || buttonsList[1][3].IsTurnedOn() || buttonsList[1][5].IsTurnedOn() || buttonsList[1][6].IsTurnedOn())
            {
                //Cannot buy skrimisher if have heavy armour
                buttonsList[4][1].TurnOffShow();
                buttonsList[4][2].TurnOffShow();
                buttonsList[4][3].TurnOffShow();
            }
            if (buttonsList[4][1].IsTurnedOn() || buttonsList[4][2].IsTurnedOn() || buttonsList[4][3].IsTurnedOn())
            {
                //Cannot buy heavy armour if they are skirmishers
                buttonsList[1][2].TurnOffShow();
                buttonsList[1][3].TurnOffShow();
                buttonsList[1][5].TurnOffShow();
                buttonsList[1][6].TurnOffShow();
            }
            if (!(buttonsList[2][2].IsTurnedOn() || buttonsList[2][3].IsTurnedOn()))
            {
                //cannot buy firearrows unless it has bows
                buttonsList[4][6].TurnOffShow();
            }
            if (buttonsList[4][6].IsTurnedOn())
            {
                //cannot buy firearrows unless it has bows
                buttonsList[2][0].TurnOffShow();
                buttonsList[2][1].TurnOffShow();
                buttonsList[2][4].TurnOffShow();
                buttonsList[2][5].TurnOffShow();
                buttonsList[2][6].TurnOffShow();
                buttonsList[2][7].TurnOffShow();
                buttonsList[2][8].TurnOffShow();
            }
        }
        public void ChangeLeaderType(BaseUnit soldierType)
        {
            if (soldierType is Artilleryman)
            {
                buttonsList[8][0].ChangeType(new ArtilleryEngineer(), "Artillery Engineer / 20pts");
            }
            else
            {
                buttonsList[8][0].ChangeType(new UnitLeader(), "UnitLeader / 10pts");
            }
        }
    }
}
