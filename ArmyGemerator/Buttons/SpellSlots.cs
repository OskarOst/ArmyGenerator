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
    class SpellSlots : AllFather
    {
        private SpellsClass spell;
        private SoundEffect crystalsound;
        private SpriteFont font;
        private int originYPost;
        private string text;
        private AllFather symbol;
        public SpellSlots(Texture2D texture, Texture2D spellSymbol, SpriteFont font, SpellsClass spell, int x, int y, SoundEffect crystalsound, int image) : base(texture, 2, 1, x, y)
        {
            symbol = new AllFather(spellSymbol, 1, 32, mainRec.X + 10, y + 10);
            symbol.currentFrame = image;
            symbol.mainRec.X = x + mainRec.Width - symbol.mainRec.Width - 10;
            this.crystalsound = crystalsound;
            originYPost = y;
            this.font = font;
            this.spell = spell;
            this.text = SpellText(spell.GetText());
        }
        public override void Repos(int x, int y)
        {
            base.Repos(x, y);
            symbol.Repos(x + mainRec.Width - 10 - symbol.mainRec.Width, y + 10);

        }
        private string SpellText(string input)
        {
            string output = "";
            string temp = "";
            string[] array = input.Split(' ');
            Rectangle rec = new Rectangle(mainRec.X + 10, 1,1,10);
            for (int i = 0; i < array.Length; i++)
            {
                int textLenght = (int)font.MeasureString(temp + array[i] + " ").X;
                textLenght = (int)(textLenght * 0.75f) + 10;
                rec.Width = textLenght;
                rec.Y = mainRec.Y + 35 + (int)(font.MeasureString(output).Y * 0.5f);
                if (rec.Intersects(symbol.mainRec))
                {
                    output += temp + Environment.NewLine;
                    temp = array[i] + " ";
                }
                else if (i == array.Length - 1)
                {
                    if (textLenght > mainRec.Width - 10)
                    {
                        output += temp + Environment.NewLine + array[i];
                    }
                    else
                    {
                        output += temp+ " " + array[i];
                    }
                }
                else if (textLenght > mainRec.Width - 10)
                {
                    output += temp + Environment.NewLine;
                    temp = array[i]+ " ";
                }
                else if (textLenght < mainRec.Width - 10)
                {
                    temp += array[i] + " ";
                }
            }
            return output;
        }
        public void Move(int i)
        {
            mainRec.Y += i;
            symbol.mainRec.Y = mainRec.Y + 10;
        }
        public void Clear()
        {
            currentFrame = 0;
        }
        public void Activate()
        {
            currentFrame = 1;
        }
        public void Play()
        {
            crystalsound.Play();
        }
        public SpellsClass GetSpells()
        {
            return spell;
        }
        public string GetSpellName()
        {
            return spell.GetName();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(font, spell.GetName(), new Vector2(mainRec.X + 10, mainRec.Y + 10), Color.Black,
            0, new Vector2(0, 0), 1f, SpriteEffects.None, 1f);
            spriteBatch.DrawString(font, text, new Vector2(mainRec.X + 10, mainRec.Y + 35), Color.Black,
               0, new Vector2(0, 0), 0.75f, SpriteEffects.None, 1f);
            symbol.Draw(spriteBatch);
        }
    }
}
