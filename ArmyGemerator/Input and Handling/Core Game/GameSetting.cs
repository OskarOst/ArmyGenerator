using System;
using System.IO;
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
    enum Thing
    {
        Army,
        Regiment,
        Settings
    }
    class GameSetting
    {
        Thing thing;
        RegimentSupport regimentSupport;
        ArmySupporter armySupporter;
        MouseState mouse;
        KeyboardState keyboard;
        Texture2D markButton;
        Texture2D armyButtons;
        Texture2D show;
        Texture2D soldierRegulateButton;
        SpriteFont font;
        BaseArmy lastArmy;
        BackGround bookBackground;
        string savePath;
        string preFabPath;
        Texture2D decoration;
        SoundEffect bookSound;
        SoundEffect crystalSound;
        SoundEffect horseSound;
        SoundEffect clickSound;
        SoundEffect swordSound;
        SoundEffect arrowSound;
        SoundEffect hireRegiment;
        Texture2D magic;
        Vector2 screenSize;
        Texture2D lineTexture;
        Texture2D upDown;
        MouseState oldmouse; 
        Texture2D mark;
        Texture2D magicSymbol;
        GraphicsSetting graphicsSetting;
        int regimentcancel;
        int screenWidth;
        int screenHeight;
        int edgeCutOff;
        int yStartPosMagic;
        int yCuttOff;
        Texture2D background;
        int xStart;
        int yStart;
        Texture2D dootTexture;
        SoundEffect doot;
        private int markButtonStartPos;
        public GameSetting(Texture2D markButton, Texture2D armyButtons, Texture2D soldierRegulateButton, Texture2D book, SpriteFont font, Texture2D decoration, 
            Texture2D upDown, Texture2D background, Texture2D mark, Texture2D sortButtons, Texture2D magic, Texture2D switchArmy, Texture2D show, 
            Texture2D spelllDecoration, SoundEffect bookSound, SoundEffect crystalSound, SoundEffect horseSound, SoundEffect clickSound, SoundEffect swordSound, 
            SoundEffect arrowSound, SoundEffect deletesound, Texture2D lineTexture, SoundEffect hireRegiment, 
            int screenWidth, int screenHeight, int xStartArmy, int yStartArmy, float scaledHeigth, float scaledWidth, int SwitchArmyButtonsPositionX, int SwitchArmyButtonsPositionY,
            int SwitchArmyButtonsPositionX2, int cutOff, int regimentcancel, int yStartPosMagic, int yCuttOff, Texture2D magicSymbol, int yStart, SoundEffect doot, Texture2D dootTexture,
            int markButtonStartPos)
        {
            this.markButtonStartPos = markButtonStartPos;
            this.doot = doot;
            this.dootTexture = dootTexture;
            this.background = background;
            this.xStart = xStartArmy;
            this.yStart = yStartArmy;
            this.magicSymbol = magicSymbol;
            this.yStartPosMagic = yStartPosMagic;
            this.yCuttOff = yCuttOff;
            this.edgeCutOff = cutOff;
            this.screenSize = new Vector2(screenWidth, screenHeight);
            this.hireRegiment = hireRegiment;
            this.lineTexture = lineTexture;
            this.arrowSound = arrowSound;
            this.swordSound = swordSound;
            this.bookSound = bookSound;
            this.show = show;
            this.decoration = decoration;
            this.clickSound = clickSound;
            this.horseSound = horseSound;
            this.magic = magic;
            this.crystalSound = crystalSound;
            this.upDown = upDown;
            this.mark = mark;
            this.regimentcancel = regimentcancel;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            savePath = System.Environment.CurrentDirectory + "\\Saves";
            preFabPath = System.Environment.CurrentDirectory + "\\Saved Regiments";
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            if (!Directory.Exists(preFabPath))
            {
                Directory.CreateDirectory(preFabPath);
            }
            this.markButton = markButton;
            this.armyButtons = armyButtons;
            this.soldierRegulateButton = soldierRegulateButton;
            this.font = font;
            bookBackground = new BackGround(book, 1, 1, 0, 0, screenWidth, screenHeight);
            thing = Thing.Army;

            regimentSupport = new RegimentSupport(markButton, armyButtons, soldierRegulateButton, font, preFabPath, decoration, show, bookSound, crystalSound, 
                horseSound, clickSound, swordSound, arrowSound, lineTexture, hireRegiment, screenSize, magic, upDown, mark, regimentcancel, screenWidth, screenHeight,
                edgeCutOff, yStartPosMagic, yCuttOff, magicSymbol, background, xStart, yStart, doot, dootTexture, markButtonStartPos);

            armySupporter = new ArmySupporter(markButton, armyButtons, soldierRegulateButton, font, savePath, decoration, upDown, background, mark, sortButtons, magic, 
                switchArmy, spelllDecoration, bookSound, clickSound, crystalSound, deletesound, lineTexture, xStartArmy, yStartArmy, screenWidth/2, screenWidth,
                scaledHeigth, scaledWidth, SwitchArmyButtonsPositionX, SwitchArmyButtonsPositionY, SwitchArmyButtonsPositionX2, cutOff, screenHeight- regimentcancel - armyButtons.Height,
                 yStart);

            graphicsSetting = new GraphicsSetting(armyButtons, font, decoration, bookSound, screenWidth, screenHeight);
        }
        public void Update()
        {
            mouse = Mouse.GetState();
            keyboard = Keyboard.GetState();

            if (thing == Thing.Army)
            {
                armySupporter.Update();
                if (armySupporter.ChangeToRegiment())
                {
                    thing = Thing.Regiment;
                    oldmouse = mouse;
                    regimentSupport.SetArmy(lastArmy);
                }
                else if (armySupporter.ChangeImportRegiment())
                {
                    thing = Thing.Regiment;
                    oldmouse = mouse;
                    regimentSupport.SetImport();
                }
                else if (armySupporter.Edit())
                {
                    thing = Thing.Regiment;
                    oldmouse = mouse;
                    regimentSupport.SetRegiment(armySupporter.GetRegiment());
                }
                else if (armySupporter.GoToSettings())
                {
                    thing = Thing.Settings;
                }
            }
            else if (thing == Thing.Regiment)
            {
                regimentSupport.Update();
                if (regimentSupport.TurnOff() || regimentSupport.DootEnd())
                {
                    lastArmy = regimentSupport.GetArmy();
                    if (armySupporter.Edit())
                    {
                        armySupporter.EditRegiments(regimentSupport.GetRegiment());
                    }
                    else
                    {
                        armySupporter.AddRegiment(regimentSupport.GetRegiment());
                    }
                    thing = Thing.Army;
                    regimentSupport = new RegimentSupport(markButton, armyButtons, soldierRegulateButton, font, preFabPath, decoration, show, bookSound, crystalSound, 
                        horseSound, clickSound, swordSound, arrowSound, lineTexture, hireRegiment, screenSize, magic, upDown, mark, regimentcancel, screenWidth, 
                        screenHeight, edgeCutOff, yStartPosMagic, yCuttOff, magicSymbol, background, xStart, yStart, doot, dootTexture, markButtonStartPos);
                }
                else if (regimentSupport.GetCancel())
                {

                    lastArmy = regimentSupport.GetArmy();
                    thing = Thing.Army;
                    regimentSupport = new RegimentSupport(markButton, armyButtons, soldierRegulateButton, font, preFabPath, decoration, show, bookSound, crystalSound, 
                        horseSound, clickSound, swordSound, arrowSound, lineTexture, hireRegiment, screenSize, magic, upDown, mark, regimentcancel, screenWidth, 
                        screenHeight, edgeCutOff, yStartPosMagic, yCuttOff, magicSymbol, background, xStart, yStart, doot, dootTexture, markButtonStartPos);
                    if (armySupporter.Edit())
                    {
                        armySupporter.EditRegiments(armySupporter.GetEditRegiment());
                    }
                }
            }
            else if (thing == Thing.Settings)
            {
                graphicsSetting.Update(mouse);
                if (graphicsSetting.ExitButtonPressed())
                {
                    thing = Thing.Army; 
                }
            }
            oldmouse = mouse;
        }
        public void ReSize(int screenWidth, int screenHeight, int xStart, int yStart, float scaledHeigth, float scaledWidth, int SwitchArmyButtonsPositionX, 
            int SwitchArmyButtonsPositionY, int SwitchArmyButtonsPositionX2, int cutOffSize, int regimentCancel, int Xedge, int markButtonStartPos, int armyStartX, 
            int armyStartY, int yStartPosMagic, int yCutoff)
        {
            bookBackground.mainRec.Width = screenWidth;
            bookBackground.mainRec.Height = screenHeight;

            armySupporter.ResizeWindows(screenWidth/2, xStart, yStart,scaledHeigth, scaledWidth, SwitchArmyButtonsPositionX, SwitchArmyButtonsPositionY, 
                SwitchArmyButtonsPositionX2, cutOffSize, screenHeight - regimentCancel - armyButtons.Height, armyStartX, armyStartY);

            regimentSupport.ResizeWindows(screenWidth / 2, screenHeight, regimentCancel, Xedge, markButtonStartPos, armyStartX, armyStartY,
                screenHeight - regimentCancel - armyButtons.Height, yStartPosMagic, yCutoff);

            graphicsSetting.Resize(screenWidth/2+ 20);
        }
        public string GetScreenSize()
        {
            return graphicsSetting.GetSize();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            bookBackground.Draw(spriteBatch);
            if (thing == Thing.Army)
            {
                armySupporter.Draw(spriteBatch);
            }
            else if (thing == Thing.Regiment)
            {
                regimentSupport.Draw(spriteBatch);
            }
            else if (thing == Thing.Settings)
            {
                graphicsSetting.Draw(spriteBatch);
            }

        }
    }
}
