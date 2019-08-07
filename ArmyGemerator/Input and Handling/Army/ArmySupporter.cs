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
    enum Armystates
    {
        Load,
        Save,
        Army
    }
    class ArmySupporter
    {
        private Save save;
        private Load load;
        private Armystates armystates;
        private MouseState mousestate;
        private MouseState oldmousestate;
        private string savePath;
        private ArmyHandler armyHandler;
        private SpriteFont font;
        private Button addRegimentbtn;
        private Button editRegimentbtn;
        private Button deleteRegimentbtn;
        private Button saveRegimentbtn;
        private Button loadRegimentbtn;
        private Button dublicateRegimentbtn;
        private Button newArmy;
        private Button addArmy;
        private Button importRegiment;
        private Button settingsbtn;

        public ArmySupporter(Texture2D markButton, Texture2D armyButtons, Texture2D soldierRegulateButton, SpriteFont font, string savePath,
            Texture2D decoration, Texture2D upDown, Texture2D background, Texture2D mark, Texture2D sortButtons, Texture2D magic,
            Texture2D switchArmy, Texture2D spelllDecoration, SoundEffect bookSound, SoundEffect clickSound, SoundEffect crystalsound,
            SoundEffect deletesound, Texture2D lineTexture, int xStart, int yStart, int pageMid, int pageSize, float scaledHeigth, 
            float scaledWidth, int SwitchArmyButtonsPositionX, int SwitchArmyButtonsPositionY, int SwitchArmyButtonsPositionX2, int cutOff,
            int buttonPos, int yLoadStart)
        {
            this.font = font;
            this.savePath = savePath;
            armystates = Armystates.Army;
            save = new Save(armyButtons, font, "Army", decoration, 3, bookSound, lineTexture);
            load = new Load(armyButtons, font, markButton, savePath, "Army", decoration, 0, clickSound, bookSound, buttonPos, background, xStart, yLoadStart, mark, upDown);


            armyHandler = new ArmyHandler(markButton, armyButtons, soldierRegulateButton, font, savePath, decoration, upDown, background, 
                mark, sortButtons, magic,  switchArmy, spelllDecoration, bookSound, clickSound, crystalsound, deletesound, lineTexture, 
                xStart, yStart, scaledHeigth, scaledWidth, SwitchArmyButtonsPositionX, SwitchArmyButtonsPositionY, SwitchArmyButtonsPositionX2,
                pageSize/2, cutOff);
            addRegimentbtn = new Button(armyButtons, 1, 2, pageMid + 30, 100, font, "Add Regiment", bookSound);
            editRegimentbtn = new Button(armyButtons, 1, 2, pageMid + 30, 150, font, "Edit Regiment", bookSound);
            deleteRegimentbtn = new Button(armyButtons, 1, 2, pageMid + 30, 200, font, "Delete Regiment", deletesound, 0.4f);
            dublicateRegimentbtn = new Button(armyButtons, 1, 2, pageMid + 30, 250, font, "Copy Regiment", bookSound);
            saveRegimentbtn = new Button(armyButtons, 1, 2, pageMid + 30, 300, font, "Save Army", bookSound);
            loadRegimentbtn = new Button(armyButtons, 1, 2, pageMid + 30, 350, font, "Load Army", bookSound);
            newArmy = new Button(armyButtons, 1, 2, pageMid + 30, 400, font, "Clear Army", bookSound);
            addArmy = new Button(armyButtons, 1, 2, pageMid + 30, 450, font, "Add Army", bookSound);
            importRegiment = new Button(armyButtons, 1, 2, pageMid + 30, 500, font, "Import Regiment", bookSound);
            settingsbtn = new Button(armyButtons, 1, 2, pageMid + 30, 550, font, "Settings", bookSound);
        }
        public void Update()
        {
            mousestate = Mouse.GetState();
            addRegimentbtn.Update(mousestate, oldmousestate);
            editRegimentbtn.Update(mousestate, oldmousestate);
            deleteRegimentbtn.Update(mousestate, oldmousestate);
            saveRegimentbtn.Update(mousestate, oldmousestate);
            loadRegimentbtn.Update(mousestate, oldmousestate);
            dublicateRegimentbtn.Update(mousestate, oldmousestate);
            settingsbtn.Update(mousestate, oldmousestate);
            if (dublicateRegimentbtn.pressed == true)
            {
                armyHandler.CopyRegiment();
            }
            else if (editRegimentbtn.pressed == true)
            {
                armyHandler.EditRegiment();
            }
            else if (deleteRegimentbtn.pressed == true)
            {
                armyHandler.DeleteRegiment();
            }
            if (armystates == Armystates.Save)
            {
                save.Update(mousestate, oldmousestate, savePath, armyHandler.GetArmy());
                if (save.Cancel())
                {
                    armystates = Armystates.Army;
                }
            }
            else if (armystates == Armystates.Load)
            {
                load.Update(mousestate, oldmousestate);
                if (load.Cancel())
                {
                    armystates = Armystates.Army;
                }
                else if (load.Loaded())
                {
                    armystates = Armystates.Army;
                    armyHandler.SetArmy((Army)load.ReturnObject());
                }
            }
            else
            {
                armyHandler.Update(mousestate, savePath);
                addArmy.Update(mousestate, oldmousestate);
                newArmy.Update(mousestate, oldmousestate);
                importRegiment.Update(mousestate, oldmousestate);
                if (newArmy.pressed == true)
                {
                    armyHandler.ClearArmy();
                }
                else if (addArmy.pressed)
                {
                    armyHandler.AddArmy();
                }
            }
            if (saveRegimentbtn.pressed == true)
            {
                armystates = Armystates.Save;

            }
            else if (loadRegimentbtn.pressed == true)
            {
                armystates = Armystates.Load;
            }
            oldmousestate = mousestate;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (armystates == Armystates.Save)
            {
                save.Draw(spriteBatch);
            }
            else if (armystates == Armystates.Load)
            {
                load.Draw(spriteBatch, font);
            }
            else
            {
                armyHandler.Draw(spriteBatch);
                editRegimentbtn.Draw(spriteBatch);
                addRegimentbtn.Draw(spriteBatch);
                deleteRegimentbtn.Draw(spriteBatch);
                dublicateRegimentbtn.Draw(spriteBatch);
                loadRegimentbtn.Draw(spriteBatch);
                saveRegimentbtn.Draw(spriteBatch);
                newArmy.Draw(spriteBatch);
                addArmy.Draw(spriteBatch);
                importRegiment.Draw(spriteBatch);
                settingsbtn.Draw(spriteBatch);
            }
        }
        public bool GoToSettings()
        {
            return settingsbtn.pressed;
        }
        public bool Edit()
        {
            if (editRegimentbtn.pressed)
            {
                return true;
            }
            else
            return false;
        }
        public bool ChangeImportRegiment()
        {
            if (importRegiment.pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Regiment GetRegiment()
        {
            return armyHandler.GetChosenRegiment();
        }
        public Regiment GetEditRegiment()
        {
            return armyHandler.GetTempRegiment();
        }
        public bool ChangeToRegiment()
        {
            if (addRegimentbtn.pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ResizeWindows(int pageMid, int xStart, int yStart, float scaledHeigth, float scaledWidth, int SwitchArmyButtonsPositionX, 
            int SwitchArmyButtonsPositionY, int SwitchArmyButtonsPositionX2, int cutOffSize, int regimentCancel, int armyStartX, int armyStartY)
        {
            addRegimentbtn.Repos(pageMid + 30, 100);
            editRegimentbtn.Repos(pageMid + 30, 150);
            deleteRegimentbtn.Repos(pageMid + 30, 200);
            dublicateRegimentbtn.Repos(pageMid + 30, 250);
            saveRegimentbtn.Repos(pageMid + 30, 300);
            loadRegimentbtn.Repos(pageMid + 30, 350);
            newArmy.Repos(pageMid + 30, 400);
            addArmy.Repos(pageMid + 30, 450);
            importRegiment.Repos(pageMid + 30, 500);
            settingsbtn.Repos(pageMid + 30, 550);
            armyHandler.Repos(xStart, yStart, scaledHeigth, scaledWidth, SwitchArmyButtonsPositionX, SwitchArmyButtonsPositionY, SwitchArmyButtonsPositionX2, pageMid, cutOffSize);
            load.Repos(armyStartX, armyStartY, regimentCancel);
        }
        public void AddRegiment(Regiment newRegiment)
        {
            armyHandler.AddRegiment(newRegiment);
        }
        public void EditRegiments(Regiment newRegiment)
        {
            armyHandler.EditRegiments(newRegiment);
        }
    }

}
