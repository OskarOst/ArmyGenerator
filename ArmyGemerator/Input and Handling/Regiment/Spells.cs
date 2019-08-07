using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
namespace ArmyGenerator
{
    class Spells
    {
        private SpriteFont font;
        private List<SpellSlots> spells;
        private int move;
        private KeyboardState keyboard;
        private KeyboardState oldKeyboard;
        private SliderClass slider;
        private SoundEffect clickSound;
        private int slideStartX;
        private int slideStartY;
        private int buttonHeight;
        public Spells(SpriteFont font, Texture2D magic, Texture2D magicSymbol, Texture2D button, Texture2D upDown, Texture2D mark, SoundEffect clickSound, SoundEffect booksound, 
            SoundEffect crystalsound, int startPos, int yStartPos,int yCuttOff)
        {
            this.clickSound = clickSound;
            move = magic.Height / 2;
            spells = new List<SpellSlots>();
            this.font = font;
            spells.Add(new SpellSlots(magic, magicSymbol, font, new FireBlast(), startPos+ 50, yStartPos, crystalsound, 0));
            spells.Add(new SpellSlots(magic, magicSymbol, font, new IceBlast(), startPos + 50, yStartPos + (1 * move), crystalsound, 1));
            spells.Add(new SpellSlots(magic, magicSymbol, font, new LightningBlast(), startPos + 50, yStartPos + (2 * move), crystalsound, 2));
            spells.Add(new SpellSlots(magic, magicSymbol, font, new EarthBlast(), startPos + 50, yStartPos + (3 * move), crystalsound, 3));
            spells.Add(new SpellSlots(magic, magicSymbol, font, new DarkBlast(), startPos + 50, yStartPos + (4 * move), crystalsound, 4));
            spells.Add(new SpellSlots(magic, magicSymbol, font, new HolyBlast(), startPos + 50, yStartPos + (5 * move), crystalsound, 5));
            spells.Add(new SpellSlots(magic, magicSymbol, font, new Healing(), startPos + 50, yStartPos + (6 * move), crystalsound, 6));
            spells.Add(new SpellSlots(magic, magicSymbol, font, new Distract(), startPos + 50, yStartPos + (7 * move), crystalsound, 7));
            spells.Add(new SpellSlots(magic, magicSymbol, font, new Panic(), startPos + 50, yStartPos + (8 * move), crystalsound, 8));
            spells.Add(new SpellSlots(magic, magicSymbol, font, new Motivate(), startPos + 50, yStartPos + (9 * move), crystalsound, 9));
            spells.Add(new SpellSlots(magic, magicSymbol, font, new Barrier(), startPos + 50, yStartPos + (10 * move), crystalsound, 10));
            spells.Add(new SpellSlots(magic, magicSymbol, font, new Weaken(), startPos + 50, yStartPos + (11 * move), crystalsound, 11));
            spells.Add(new SpellSlots(magic, magicSymbol, font, new FireSummon(), startPos + 50, yStartPos + (12 * move), crystalsound, 12));
            spells.Add(new SpellSlots(magic, magicSymbol, font, new IceSummon(), startPos + 50, yStartPos + (13 * move), crystalsound, 13));
            spells.Add(new SpellSlots(magic, magicSymbol, font, new AirSummon(), startPos + 50, yStartPos + (14 * move), crystalsound, 14));
            spells.Add(new SpellSlots(magic, magicSymbol, font, new EarthSummon(), startPos + 50, yStartPos + (15 * move), crystalsound, 15));
            spells.Add(new SpellSlots(magic, magicSymbol, font, new DarkSummon(), startPos + 50, yStartPos + (16 * move), crystalsound, 16));
            spells.Add(new SpellSlots(magic, magicSymbol, font, new HolySummon(), startPos + 50, yStartPos + (17 * move), crystalsound, 17));

            buttonHeight = upDown.Height;
            slider = new SliderClass(mark, upDown, yCuttOff - yStartPos - upDown.Height- mark.Height, 5, yStartPos + upDown.Height, startPos, yStartPos, yCuttOff - upDown.Height, startPos - (mark.Width / 2) + upDown.Width / 4, spells[0].mainRec.Height);
            slideStartX =startPos;
            slideStartY = yStartPos;
        }
        public void Update(MouseState mousestate, MouseState oldmousestate)
        {
            keyboard = Keyboard.GetState();
            slider.Update(mousestate, oldmousestate, 18);
            for (int i = 0; i < spells.Count; i++)
            {
                spells[i].Update(mousestate, oldmousestate);
            }
            if (slider.ChangeButtons(mousestate, oldmousestate))
            {
                Move(slider.GetMoveDirection(mousestate, oldmousestate));
            }
            oldKeyboard = keyboard;
        }
        public void Repos(int startPos, int yStartPos,int yCutoff, int screenHight)
        {
            for (int i = 0; i < spells.Count; i++)
            {
                spells[i].Repos(startPos + 50, yStartPos + (i * move));
            }
            slider.Resize(startPos, yStartPos + 20, screenHight- yCutoff - buttonHeight, spells[0].mainRec.Height);
        }
        public bool Pressed()
        {
            for (int i = 0; i < spells.Count; i++)
            {
                if (spells[i].pressed)
                {
                    return true;
                }
            }
            return false;
        }
        public void reset(List<SpellsClass> input)
        {
            for (int i = 0; i < spells.Count; i++)
            {
                spells[i].Clear();
                for (int p = 0; p < input.Count; p++)
                {
                    if (input[p] != null)
                    {
                        if (spells[i].GetSpellName() == input[p].GetName())
                        {
                            spells[i].Activate();
                        }
                    }
                }
            }
        }
        public SpellsClass GetSpells()
        {
            for (int i = 0; i < spells.Count; i++)
            {
                if (spells[i].pressed)
                {
                    return spells[i].GetSpells();
                }
            }
            return null;
        }
        private void Move(int input)
        {
            for (int i = 0; i < spells.Count; i++)
            {
                spells[i].Move(input);
            }
        }
        private void Up()
        {
            for (int i = 0; i < spells.Count; i++)
            {
                spells[i].Move(move);
            }
        }
        private void Down()
        {
            for (int i = 0; i < spells.Count; i++)
            {
                spells[i].Move(0 - move);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            slider.Draw(spriteBatch, slideStartX, slideStartY);
            for (int i = slider.DrawFrom(); i < slider.DrawFrom() + slider.GetDrawingLenght(); i++)
            {
                if(i < spells.Count)
                    spells[i].Draw(spriteBatch);
            }
        }
    }
}
