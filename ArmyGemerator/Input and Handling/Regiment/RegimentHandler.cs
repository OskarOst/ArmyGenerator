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
    enum EquipmentState
    {
        equipment,
        spells
    }
    class RegimentHandler
    {
        private BaseArmy army;
        private List<BaseArmy> armies;
        private List<Button> armiesButtons;
        private Button endTheThing;
        private List<NumberOfSoldierButton> numbersOfSoldiersButtons;
        private List<MarkButton> typeOfUnitButtons;
        private MarkButtonHandler equipmentbuttonHandler;
        private Spells spellHandler;
        private Button spellBTN;
        private Button equipmentBTN;
        private ItemAdder itemAdder;
        private List<int> pressedWeaponsButtons;
        private Regiment regiment;
        private SpriteFont font;
        private float scale;
        private Texture2D markButton;
        private int textPos;
        string ChosenUnit;
        private TextHandler texthandler;
        private SoundEffect bookSound;
        private SoundEffect clickSound;
        private EquipmentState state;
        private Doot doot;
        private Texture2D dootTexture;
        private SoundEffect dootSound;
        private Random random;
        private Vector2 screenSize;

        public RegimentHandler(Texture2D markButton, Texture2D armyButtons, Texture2D soldierRegulateButton, SpriteFont font, string loadPath, Texture2D decoration,
            Texture2D show, SoundEffect bookSound, SoundEffect crystalSound, SoundEffect horseSound, SoundEffect clickSound, SoundEffect swordSound,
            SoundEffect arrowSound, Texture2D lineTexture, SoundEffect hireRegiment, Vector2 screenSize, Texture2D magic, Texture2D upDown, Texture2D mark,
            int buttonPosition, int cutoff, int yStartPosMagic, int yCuttOff, Texture2D magicSymbol, SoundEffect doot, Texture2D dootTexture, int markButtonStartPos)
        {
            this.screenSize = screenSize;
            random = new Random();
            this.dootTexture = dootTexture;
            this.dootSound = doot;
            state = EquipmentState.equipment;
            scale = 0.75f;
            this.clickSound = clickSound;
            this.bookSound = bookSound;
            texthandler = new TextHandler();
            this.font = font;
            this.markButton = markButton;
            armiesButtons = new List<Button>();
            numbersOfSoldiersButtons = new List<NumberOfSoldierButton>();
            equipmentbuttonHandler = new MarkButtonHandler(markButton, show, horseSound, clickSound, swordSound, arrowSound, screenSize, font, buttonPosition, cutoff,
                (int)screenSize.X / 2 + 20, markButtonStartPos);

            spellHandler = new Spells(font, magic, magicSymbol, armyButtons, upDown, mark, clickSound, bookSound, crystalSound, (int)screenSize.X / 2 + 20, yStartPosMagic, yCuttOff);

            armies = new List<BaseArmy>();
            armies.Add(new Beastmen());
            armies.Add(new Centaur());
            armies.Add(new Creatures());
            armies.Add(new Demon());
            armies.Add(new Dryads());
            armies.Add(new Dwarf());
            armies.Add(new Elf());
            armies.Add(new Goblins());
            armies.Add(new Halfling());
            armies.Add(new Hobgoblin());
            armies.Add(new Human());
            armies.Add(new Lizardmen());
            armies.Add(new Ogre());
            armies.Add(new Orc());
            armies.Add(new Ratmen());
            armies.Add(new Barbarians());
            armies.Add(new Undead());
            pressedWeaponsButtons = new List<int>();
            itemAdder = new ItemAdder();
            int y = 0;
            int x = 0;
            for (int i = 0; i < armies.Count; i++)
            {
                armiesButtons.Add(new Button(armyButtons, 1, 2, (int)screenSize.X / 2 + 20 + ((armyButtons.Width / 2 * x) + (5 * x)), equipmentbuttonHandler.NumberOfLines() + (armyButtons.Height * y) + (5 * y), font, armies[i].name, bookSound));
                if (armiesButtons[i].mainRec.X + (5 * (x)) + armiesButtons[i].mainRec.Width > cutoff)
                {
                    x = 0;
                    y++;
                }
                else
                {
                    x++;
                }
            }
            endTheThing = new Button(armyButtons, 1, 2, 110, buttonPosition, font, "Add Regiment", hireRegiment);
            spellBTN = new Button(armyButtons, 1, 2, 510, buttonPosition, font, "Spells", bookSound);
            equipmentBTN = new Button(armyButtons, 1, 2, 510, buttonPosition, font, "Equipment", bookSound);
            regiment = new Regiment();
            typeOfUnitButtons = new List<MarkButton>();
            army = new BaseArmy();
            Equipment equipmentinput = new Equipment();
            ChosenUnit = "";
            numbersOfSoldiersButtons.Add(new NumberOfSoldierButton(soldierRegulateButton, 2, 4, (25 * 0 + 120), (25 * 1), font, 1, crystalSound));
            numbersOfSoldiersButtons[numbersOfSoldiersButtons.Count - 1].currentFrame = numbersOfSoldiersButtons.Count - 1;
            numbersOfSoldiersButtons.Add(new NumberOfSoldierButton(soldierRegulateButton, 2, 4, (25 * 1 + 120), (25 * 1), font, 10, crystalSound));
            numbersOfSoldiersButtons[numbersOfSoldiersButtons.Count - 1].currentFrame = numbersOfSoldiersButtons.Count - 1;
            numbersOfSoldiersButtons.Add(new NumberOfSoldierButton(soldierRegulateButton, 2, 4, (25 * 2 + 120), (25 * 1), font, 20, crystalSound));
            numbersOfSoldiersButtons[numbersOfSoldiersButtons.Count - 1].currentFrame = numbersOfSoldiersButtons.Count - 1;
            numbersOfSoldiersButtons.Add(new RoundUpNumberOfSoldierButton(soldierRegulateButton, 2, 4, (25 * 3 + 120), (25 * 1), font, 1, crystalSound));
            numbersOfSoldiersButtons[numbersOfSoldiersButtons.Count - 1].currentFrame = numbersOfSoldiersButtons.Count - 1;

            numbersOfSoldiersButtons.Add(new NumberOfSoldierButton(soldierRegulateButton, 2, 4, (25 * 0 + 120), (25 * 2), font, -1, crystalSound));
            numbersOfSoldiersButtons[numbersOfSoldiersButtons.Count - 1].currentFrame = numbersOfSoldiersButtons.Count - 1;
            numbersOfSoldiersButtons.Add(new NumberOfSoldierButton(soldierRegulateButton, 2, 4, (25 * 1 + 120), (25 * 2), font, -10, crystalSound));
            numbersOfSoldiersButtons[numbersOfSoldiersButtons.Count - 1].currentFrame = numbersOfSoldiersButtons.Count - 1;
            numbersOfSoldiersButtons.Add(new NumberOfSoldierButton(soldierRegulateButton, 2, 4, (25 * 2 + 120), (25 * 2), font, -20, crystalSound));
            numbersOfSoldiersButtons[numbersOfSoldiersButtons.Count - 1].currentFrame = numbersOfSoldiersButtons.Count - 1;
            numbersOfSoldiersButtons.Add(new RoundUpNumberOfSoldierButton(soldierRegulateButton, 2, 4, (25 * 3 + 120), (25 * 2), font, -1, crystalSound));
            numbersOfSoldiersButtons[numbersOfSoldiersButtons.Count - 1].currentFrame = numbersOfSoldiersButtons.Count - 1;
            equipmentbuttonHandler.CheckCanSee(regiment.ReturnType());
        }
        public void Doot(MouseState mousestate, MouseState oldMosueState)
        {
            doot.Update(mousestate, oldMosueState);
        }
        public bool DootEnd()
        {
            if (doot == null)
                return false;
            return doot.End();
        }
        public bool DootTime()
        {
            if (doot != null)
            {
                return true;
            }
            return false;
        }
        public void Update(MouseState mousestate, MouseState oldMosueState, string path)
        {
            if (state == EquipmentState.equipment)
            {
                if (equipmentbuttonHandler.Update(mousestate, oldMosueState, regiment.ReturnType()))
                {
                    if (equipmentbuttonHandler.RemoveItem())
                    {
                        regiment.RemoveEquipment(equipmentbuttonHandler.GetEquipment());
                    }
                    else
                    {
                        regiment.SetEquipment(equipmentbuttonHandler.GetEquipment());
                    }
                    equipmentbuttonHandler.UpdateShow(regiment.GetEquipment(), regiment.GetSoldier());
                    regiment.SetCost((regiment.ReturnType().GetCost() * regiment.GetNumberOfSoldiers()) + regiment.ReturnType().GetOneTimeCost() + regiment.ReturnType().GetArcherPlatformCost(regiment.GetNumberOfSoldiers()));
                }
                for (int i = 0; i < armiesButtons.Count; i++)
                {
                    armiesButtons[i].Update(mousestate, oldMosueState);
                    if (armiesButtons[i].pressed == true)
                    {
                        if (armies[i].soldiers.Count > 0)
                        {
                            army = armies[i];
                            CreateArmy();
                            int y = 0;
                            for (int p = 0; p < numbersOfSoldiersButtons.Count; p++)
                            {
                                if (p >= numbersOfSoldiersButtons.Count / 2)
                                {
                                    y = 1;
                                }
                                numbersOfSoldiersButtons[p].mainRec.Y = (textPos + 200 + (y * 25));
                            }
                            equipmentbuttonHandler.CheckCanSee(army.soldiers[0]);
                        }
                        else
                        {
                            army = armies[i];
                            CreateArmy();
                            int y = 0;
                            for (int p = 0; p < numbersOfSoldiersButtons.Count; p++)
                            {
                                numbersOfSoldiersButtons[p].mainRec.Y = (textPos + 190 + (y * 25));
                                if (p >= numbersOfSoldiersButtons.Count / 2)
                                {
                                    y = 1;
                                }
                            }
                            equipmentbuttonHandler.CheckCanSee(army.soldiers[0]);
                        }
                        regiment.SetCost((regiment.ReturnType().GetCost() * regiment.GetNumberOfSoldiers()) + regiment.ReturnType().GetOneTimeCost() + regiment.ReturnType().GetArcherPlatformCost(regiment.GetNumberOfSoldiers()));
                    }
                }
            }
            else if (state == EquipmentState.spells)
            {
                spellHandler.Update(mousestate, oldMosueState);
                if (spellHandler.Pressed())
                {
                    regiment.AddSpell(spellHandler.GetSpells());
                    spellHandler.reset(regiment.GetSpellList());
                }
            }
            if (regiment.ReturnType() is BaseUnit)
            {
                endTheThing.Update(mousestate, oldMosueState);
                if (state == EquipmentState.equipment)
                {
                    if (regiment.ReturnType().IsSpellcaster())
                    {
                        spellBTN.Update(mousestate, oldMosueState);
                        if (spellBTN.pressed)
                        {
                            state = EquipmentState.spells;
                        }
                    }
                }
                else if (state == EquipmentState.spells)
                {
                    equipmentBTN.Update(mousestate, oldMosueState);
                    if (equipmentBTN.pressed)
                    {
                        state = EquipmentState.equipment;
                    }
                }
            }

            UpdateButton(typeOfUnitButtons, mousestate, oldMosueState);
            for (int i = 0; i < typeOfUnitButtons.Count; i++)
            {
                if (typeOfUnitButtons[i].pressed == true)
                {
                    if (army.soldiers.Count > 0)
                    {
                        typeOfUnitButtons[i].Sound();
                        regiment.AppointSoldier(army.ChosenSoldier(i));
                        equipmentbuttonHandler.ChangeLeaderType(regiment.ReturnType());
                        //equipmentbuttonHandler.startOver(regiment.ReturnType());
                    }
                    else
                    {
                        typeOfUnitButtons[i].Sound();
                        regiment.AppointSoldier(army.ChosenSoldier(i));
                        equipmentbuttonHandler.ChangeLeaderType(regiment.ReturnType());
                        //equipmentbuttonHandler.startOver(regiment.ReturnType());
                    }
                    regiment.SetCost((regiment.ReturnType().GetCost() * regiment.GetNumberOfSoldiers()) + regiment.ReturnType().GetOneTimeCost() + regiment.ReturnType().GetArcherPlatformCost(regiment.GetNumberOfSoldiers()));
                }
            }
            if (regiment.GetSoldier() != null)
            {
                ChosenUnit = texthandler.NameText(regiment.GetSoldier(), regiment.GetNumberOfSoldiers(), font, regiment.GetEndCost());
                //regiment.SetCost(texthandler.ReturnEndpoints());
                if (!regiment.GetSoldier().loner)
                {
                    for (int i = 0; i < numbersOfSoldiersButtons.Count; i++)
                    {
                        numbersOfSoldiersButtons[i].Update(mousestate, oldMosueState, 0);
                        if (numbersOfSoldiersButtons[i].pressed)
                        {
                            if (numbersOfSoldiersButtons[i] is RoundUpNumberOfSoldierButton)
                            {
                                regiment.ChangeNumberOfSoldiers((numbersOfSoldiersButtons[i] as RoundUpNumberOfSoldierButton).Rounding(regiment.GetNumberOfSoldiers()));
                            }
                            else
                            {
                                regiment.ChangeNumberOfSoldiers(numbersOfSoldiersButtons[i].NumberOfSoldiers());
                            }
                            regiment.SetCost((regiment.ReturnType().GetCost() * regiment.GetNumberOfSoldiers()) + regiment.ReturnType().GetOneTimeCost() + regiment.ReturnType().GetArcherPlatformCost(regiment.GetNumberOfSoldiers()));
                        }
                    }
                }
            }
        }
        private void UpdateButton(List<MarkButton> list, MouseState mousestate, MouseState oldMosueState)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Update(mousestate, oldMosueState);
                if (list[i].pressed == true && list[i].state == State.Off)
                {
                    for (int p = 0; p < list.Count; p++)
                    {
                        list[p].Clear();
                    }
                    list[i].ChangeState();
                }
            }
        }
        public void ResizeWindows(int buttonPosition, int halfwaypoint, int cutoff, int markButtonStartPos, int yStartPosMagic, int yCutoff, int screenHeight)
        {
            int p = 0;
            endTheThing.Repos(110, buttonPosition);
            spellBTN.Repos(510, buttonPosition);
            equipmentBTN.Repos(510, buttonPosition);
            int xtemp = 0;
            int ytemp = 0;
            int xPos;
            equipmentbuttonHandler.ResizeWindows(halfwaypoint + 20, cutoff, markButtonStartPos, buttonPosition - 20);
            for (int i = 0; i < armiesButtons.Count; i++)
            {
                xPos = halfwaypoint + 20 + (armiesButtons[i].mainRec.Width * xtemp) + (5 * xtemp);
                armiesButtons[i].Repos(xPos, equipmentbuttonHandler.NumberOfLines() + (armiesButtons[i].mainRec.Height * ytemp) + (5 * ytemp));
                if (xPos + (armiesButtons[i].mainRec.Width + (5 * (xtemp)) + armiesButtons[i].mainRec.Width) > cutoff)
                {
                    xtemp = 0;
                    ytemp++;
                }
                else
                {
                    xtemp++;
                }
            }
            spellHandler.Repos(halfwaypoint + 20, yStartPosMagic, yCutoff, screenHeight);
        }

        public void CreateArmy()
        {
            if (army.SizeOfArmy() != 0)
            {
                typeOfUnitButtons = new List<MarkButton>();
                for (int i = 0; i < army.SizeOfArmy(); i++)
                {
                    typeOfUnitButtons.Add(new MarkButton(markButton, 2, 1, 120, 100 + (20 * i), army.soldiers[i].Name(), clickSound));
                }
                typeOfUnitButtons[0].ChangeState();
                regiment.AppointSoldier(army.ChosenSoldier(0));
                textPos = typeOfUnitButtons[typeOfUnitButtons.Count - 1].mainRec.Y + 60;
            }
            else if (army.SizeOfArmy() != 0)
            {
                typeOfUnitButtons = new List<MarkButton>();
                for (int i = 0; i < army.SizeOfArmy(); i++)
                {
                    typeOfUnitButtons.Add(new MarkButton(markButton, 2, 1, 120, 100 + (20 * i), army.soldiers[i].Name(), clickSound));
                }
                typeOfUnitButtons[0].ChangeState();
                regiment.AppointSoldier(army.ChosenSoldier(0));
                textPos = typeOfUnitButtons[typeOfUnitButtons.Count - 1].mainRec.Y + 60;
            }
        }
        public bool TurnOff()
        {
            if (endTheThing.pressed == true && !(regiment.ReturnType() == null))
            {
                if (regiment.GetName().Contains("Skeleton"))
                {
                    doot = new Doot(dootSound, dootTexture, random.Next(0, (int)(screenSize.X - dootTexture.Width)), random.Next(0, (int)(screenSize.Y - dootTexture.Height)));
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public Regiment GetRegiment()
        {
            return regiment;
        }
        public void DootDraw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch);
            doot.Draw(spriteBatch);
        }
        public void Draw(SpriteBatch spritebatch)
        {
            if (regiment.ReturnType() != null)
            {
                endTheThing.Draw(spritebatch);
                if (state == EquipmentState.equipment)
                {
                    if (regiment.ReturnType().IsSpellcaster())
                    {
                        spellBTN.Draw(spritebatch);
                    }
                }
                else if (state == EquipmentState.spells)
                {
                    equipmentBTN.Draw(spritebatch);
                }
                if (!regiment.GetSoldier().loner)
                {
                    for (int i = 0; i < numbersOfSoldiersButtons.Count; i++)
                    {
                        numbersOfSoldiersButtons[i].Draw(spritebatch);
                    }
                }
            }
            for (int i = 0; i < typeOfUnitButtons.Count; i++)
            {
                typeOfUnitButtons[i].Draw(spritebatch);
                spritebatch.DrawString(font, typeOfUnitButtons[i].Text(), new Vector2(typeOfUnitButtons[i].mainRec.X + 20, typeOfUnitButtons[i].mainRec.Y), Color.Black, 0,
                    new Vector2(0, 0), 0.75f, SpriteEffects.None, 1f);
            }
            spritebatch.DrawString(font, ChosenUnit, new Vector2(120, textPos), Color.Black, 0, new Vector2(0, 0), scale, SpriteEffects.None, 1f);
            if (state == EquipmentState.equipment)
            {
                for (int i = 0; i < armiesButtons.Count; i++)
                {
                    armiesButtons[i].Draw(spritebatch);
                }
                equipmentbuttonHandler.Draw(spritebatch, font, regiment.ReturnType());
            }
            else if (state == EquipmentState.spells)
            {
                spellHandler.Draw(spritebatch);
            }
        }
        public void SetRegiment(Regiment regiment)
        {
            this.regiment = regiment;
            equipmentbuttonHandler.UpdateShow(regiment.GetEquipment(), this.regiment.ReturnType());
            army = armies[regiment.GetSoldier().GetArmy()];
            typeOfUnitButtons = new List<MarkButton>();
            for (int p = 0; p < army.SizeOfArmy(); p++)
            {
                typeOfUnitButtons.Add(new MarkButton(markButton, 2, 1, 120, 100 + (20 * p), army.soldiers[p].Name(), clickSound));
                if (regiment.GetSoldier().Name() == typeOfUnitButtons[p].Text())
                {
                    typeOfUnitButtons[p].turnOn();
                }
            }
            textPos = typeOfUnitButtons[typeOfUnitButtons.Count - 1].mainRec.Y + 60;
            int y = 0;
            for (int p = 0; p < numbersOfSoldiersButtons.Count; p++)
            {
                numbersOfSoldiersButtons[p].mainRec.Y = (textPos + 180 + ((y / 2) * 25));
                y++;
            }
            pressedWeaponsButtons = new List<int>();
        }
        public void SetArmy(BaseArmy army)
        {
            if (army.soldiers.Count > 0)
            {
                this.army = army;
                CreateArmy();
                int y = 0;
                for (int p = 0; p < numbersOfSoldiersButtons.Count; p++)
                {
                    numbersOfSoldiersButtons[p].mainRec.Y = (textPos + 180 + ((y / 2) * 25));
                    y++;
                }
                regiment = new Regiment();
                regiment.AppointSoldier(army.soldiers[0]);
            }
        }
        public void ResetArmy()
        {
        }
        public BaseArmy GetArmy()
        {
            return army;
        }

    }
}
