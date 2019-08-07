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
    enum States
    {
        Load,
        Save,
        Name,
        Regiment, 
        Doot
    }
    class RegimentSupport
    {
        private States state;
        private Button cancelBTN;
        private Button exportRegimentBTN;
        private Button importRegimentBTN;
        private Button nameRegimentBTN;
        private MouseState mousestate;
        private MouseState oldMosueState;
        private RegimentHandler RegimentHandler;
        private UnitLoad loadRegiment;
        private UnitSave saveRegiment;
        private Name nameRegiment;
        private SpriteFont font;
        private string path;
        private bool cancel;
        private int regimentCancel;
        private int edgeCutOff;

        public RegimentSupport(Texture2D markButton, Texture2D armyButtons, Texture2D soldierRegulateButton, SpriteFont font, string loadPath, Texture2D decoration,
            Texture2D show, SoundEffect bookSound, SoundEffect crystalSound, SoundEffect horseSound, SoundEffect clickSound, SoundEffect swordSound,
            SoundEffect arrowSound, Texture2D lineTexture, SoundEffect hireRegiment, Vector2 screenSize, Texture2D magic, Texture2D upDown, Texture2D mark, 
            int regimentCancel, int screenWidth, int screenHeight, int edgeCutOff, int yStartPosMagic, int yCuttOff, Texture2D magicSymbol, Texture2D background,
            int xStart, int yStart, SoundEffect doot, Texture2D dootTexture, int markButtonStartPos)
        {
            this.regimentCancel = regimentCancel;
            this.font = font;
            this.edgeCutOff = edgeCutOff;
            state = States.Regiment;
            int buttonPos = screenHeight - regimentCancel - armyButtons.Height;
            RegimentHandler = new RegimentHandler(markButton, armyButtons, soldierRegulateButton, font, loadPath, decoration, show, bookSound, crystalSound, horseSound, 
            clickSound, swordSound, arrowSound, lineTexture, hireRegiment,screenSize,magic,upDown, mark, buttonPos - armyButtons.Height - 5, edgeCutOff, yStartPosMagic, 
            yCuttOff, magicSymbol, doot, dootTexture, markButtonStartPos);
            saveRegiment = new UnitSave(armyButtons, font, "Regiment", decoration, 2, markButton, loadPath, clickSound, bookSound, lineTexture,background, xStart, yStart, mark, upDown);
            loadRegiment = new UnitLoad(armyButtons, font, markButton, loadPath, "Regiment", decoration, 1, armyButtons, clickSound, bookSound, background, xStart, yStart,
                mark, upDown, screenWidth/2);
            nameRegiment = new Name(armyButtons, lineTexture, font, decoration, 2, bookSound);
            cancelBTN = new Button(armyButtons, 1, 2, 310, buttonPos - armyButtons.Height - 5, font, "Cancel", bookSound);
            exportRegimentBTN = new Button(armyButtons, 1, 2, 110, buttonPos, font, "Export Regiment", bookSound);
            importRegimentBTN = new Button(armyButtons, 1, 2, 310, buttonPos, font, "Import Regiment", bookSound);
            nameRegimentBTN = new Button(armyButtons, 1, 2, 510, buttonPos, font, "Name Regiment", bookSound);
            path = loadPath;
        }
        public void Doot(MouseState mousestate, MouseState oldMosueState)
        {
            RegimentHandler.Doot(mousestate,oldMosueState);
        }
        public bool DootEnd()
        {
            return RegimentHandler.DootEnd();
        }
        public bool DootTime()
        {
            return RegimentHandler.DootTime();
        }
        public void Update()
        {
            mousestate = Mouse.GetState();
            if (cancelBTN.pressed == true)
            {
                cancel = true;
            }
            if (state == States.Regiment)
            {
                exportRegimentBTN.Update(mousestate, oldMosueState);
                importRegimentBTN.Update(mousestate, oldMosueState);
                nameRegimentBTN.Update(mousestate, oldMosueState);
                RegimentHandler.Update(mousestate, oldMosueState, path);
                if (exportRegimentBTN.pressed == true)
                {
                    state = States.Save;
                }
                else if (nameRegimentBTN.pressed == true)
                {
                    state = States.Name;
                }
                else if (importRegimentBTN.pressed == true)
                {
                    state = States.Load;
                }
                cancelBTN.Update(mousestate, oldMosueState);
                if (RegimentHandler.DootTime())
                {
                    state = States.Doot;
                }
            }
            else if (state == States.Doot)
            {
                RegimentHandler.Doot(mousestate, oldMosueState);
            }
            else if (state == States.Load)
            {
                loadRegiment.Update(mousestate, oldMosueState);
                if (loadRegiment.Cancel())
                {
                    state = States.Regiment;
                }
                else if (loadRegiment.Loaded())
                {
                    RegimentHandler.SetRegiment((Regiment)loadRegiment.ReturnObject());
                    state = States.Regiment;
                    RegimentHandler.GetRegiment().SetName(loadRegiment.LoadName());
                }
            }
            else if (state == States.Save)
            {
                saveRegiment.Update(mousestate, oldMosueState, path, RegimentHandler.GetRegiment());
                if (saveRegiment.Cancel())
                {
                    state = States.Regiment;
                }
            }
            else if (state == States.Name)
            {
                nameRegiment.Update(mousestate, oldMosueState, RegimentHandler.GetRegiment(), RegimentHandler.GetRegiment().ReturnType().ToString());
                if (nameRegiment.Cancel())
                {
                    state = States.Regiment;
                }
                if (nameRegiment.ReturnName())
                {
                    state = States.Regiment;
                    RegimentHandler.GetRegiment().SetName(nameRegiment.GetName());
                }
            }
            oldMosueState = mousestate;
        }
        public bool TurnOff()
        {
            return RegimentHandler.TurnOff();
        }
        public void SetRegiment(Regiment regiment)
        {
            RegimentHandler.SetRegiment(regiment);
        }
        public void SetArmy(BaseArmy army)
        {
            if (army != null)
            {
                RegimentHandler.SetArmy(army);
            }
        }
        public bool GetCancel()
        {
            return cancel;
        }
        public void SetImport()
        {
            state = States.Load;
        }
        public void ResizeWindows(int halfwaypoint, int screenHeight, int regimentCancel, int xEdge, int markButtonStartPos, int loadStartX, int loadStarty, 
            int loadButton, int yStartPosMagic, int yCutoff)
        {
            int buttonPos = screenHeight - regimentCancel - cancelBTN.mainRec.Height;
            exportRegimentBTN.Repos(110, buttonPos);
            importRegimentBTN.Repos(310, buttonPos);
            nameRegimentBTN.Repos(510, buttonPos);
            cancelBTN.Repos(310, buttonPos - cancelBTN.mainRec.Height - 5);
            RegimentHandler.ResizeWindows(buttonPos - cancelBTN.mainRec.Height - 5, halfwaypoint, xEdge, markButtonStartPos, yStartPosMagic, yCutoff, screenHeight);
            loadRegiment.Repos(loadStartX, loadStarty, loadButton, halfwaypoint+20);
            saveRegiment.Repos(loadStartX, loadStarty + 20);
            
        }
        public void Draw(SpriteBatch spritebatch)
        {
            if (state == States.Regiment)
            {
                exportRegimentBTN.Draw(spritebatch);
                importRegimentBTN.Draw(spritebatch);
                nameRegimentBTN.Draw(spritebatch);
                cancelBTN.Draw(spritebatch);
                RegimentHandler.Draw(spritebatch);
            }
            else if (state == States.Doot)
            {
                RegimentHandler.DootDraw(spritebatch);
            }
            else if (state == States.Save)
            {
                saveRegiment.Draw(spritebatch);
            }
            else if (state == States.Name)
            {
                nameRegiment.Draw(spritebatch, font);
            }
            else if (state == States.Load)
            {
                loadRegiment.Draw(spritebatch, font);
            }
        }
        public BaseArmy GetArmy()
        {
            return RegimentHandler.GetArmy();
        }
        public Regiment GetRegiment()
        {
            return RegimentHandler.GetRegiment();
        }
    }
}
