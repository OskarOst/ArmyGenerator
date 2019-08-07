using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
namespace ArmyGenerator
{
    class WriteClass
    {
        private int countdown;
        private int countdown2;
        private int textCountdown;
        private int textCountdown2;
        private float textscale;
        SpriteFont font;
        private Line line;
        private string text;
        private int x;
        private int y;
        public WriteClass(SpriteFont font, Texture2D sprite, int x, int y)
        {
            textscale = 0.75f;
            text = "";
            this.x = x;
            this.y = y;
            this.font = font;
            line = new Line(sprite, x, y - 2);
            countdown = 0;
            countdown2 = 0;
            textCountdown = 0;
            textCountdown2 = 0;
        }
        public void Repos(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Update(KeyboardState keyboard, KeyboardState oldkeyboard)
        {
            if (keyboard.IsKeyDown(Keys.Back) && oldkeyboard.IsKeyUp(Keys.Back) && text.Length != 0)
            {
                text = text.Remove(text.Length - 1);
            }
            else if (keyboard.IsKeyDown(Keys.Back) && text.Length != 0)
            {
                if (countdown > 20)
                {
                    countdown2++;
                    if (countdown2 > 2)
                    {
                        text = text.Remove(text.Length - 1);
                        countdown2 = 0;
                    }
                }
                else
                {
                    countdown++;
                }
            }
            else if (keyboard.IsKeyUp(Keys.Back) && oldkeyboard.IsKeyDown(Keys.Back))
            {
                countdown = 0;
            }
            else if (keyboard.IsKeyDown(Keys.Space) && oldkeyboard.IsKeyUp(Keys.Space))
            {
                text = text + " ";
            }
            else if (keyboard.IsKeyDown(Keys.LeftShift) || keyboard.IsKeyDown(Keys.RightShift))
            {
                if (keyboard.IsKeyDown(Keys.A) && oldkeyboard.IsKeyUp(Keys.A))
                {
                    text = text + "A";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.B) && oldkeyboard.IsKeyUp(Keys.B))
                {
                    text = text + "B";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.C) && oldkeyboard.IsKeyUp(Keys.C))
                {
                    text = text + "C";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.D) && oldkeyboard.IsKeyUp(Keys.D))
                {
                    text = text + "D";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.E) && oldkeyboard.IsKeyUp(Keys.E))
                {
                    text = text + "E";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.F) && oldkeyboard.IsKeyUp(Keys.F))
                {
                    text = text + "F";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.G) && oldkeyboard.IsKeyUp(Keys.G))
                {
                    text = text + "G";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.H) && oldkeyboard.IsKeyUp(Keys.H))
                {
                    text = text + "H";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.I) && oldkeyboard.IsKeyUp(Keys.I))
                {
                    text = text + "I";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.J) && oldkeyboard.IsKeyUp(Keys.J))
                {
                    text = text + "J";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.K) && oldkeyboard.IsKeyUp(Keys.K))
                {
                    text = text + "K";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.L) && oldkeyboard.IsKeyUp(Keys.L))
                {
                    text = text + "L";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.M) && oldkeyboard.IsKeyUp(Keys.M))
                {
                    text = text + "M";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.N) && oldkeyboard.IsKeyUp(Keys.N))
                {
                    text = text + "N";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.O) && oldkeyboard.IsKeyUp(Keys.O))
                {
                    text = text + "O";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.P) && oldkeyboard.IsKeyUp(Keys.P))
                {
                    text = text + "P";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.Q) && oldkeyboard.IsKeyUp(Keys.Q))
                {
                    text = text + "Q";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.R) && oldkeyboard.IsKeyUp(Keys.R))
                {
                    text = text + "R";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.S) && oldkeyboard.IsKeyUp(Keys.S))
                {
                    text = text + "S";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.T) && oldkeyboard.IsKeyUp(Keys.T))
                {
                    text = text + "T";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.U) && oldkeyboard.IsKeyUp(Keys.U))
                {
                    text = text + "U";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.V) && oldkeyboard.IsKeyUp(Keys.V))
                {
                    text = text + "V";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.W) && oldkeyboard.IsKeyUp(Keys.W))
                {
                    text = text + "W";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.X) && oldkeyboard.IsKeyUp(Keys.X))
                {
                    text = text + "X";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.Y) && oldkeyboard.IsKeyUp(Keys.Y))
                {
                    text = text + "Y";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.Z) && oldkeyboard.IsKeyUp(Keys.Z))
                {
                    text = text + "Z";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.D8) && oldkeyboard.IsKeyUp(Keys.D8))
                {
                    text = text + "(";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.D9) && oldkeyboard.IsKeyUp(Keys.D9))
                {
                    text = text + ")";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.A))
                {
                    text = Masswrite(text, "A");
                }
                else if (keyboard.IsKeyDown(Keys.B))
                {
                    text = Masswrite(text, "B");
                }
                else if (keyboard.IsKeyDown(Keys.C))
                {
                    text = Masswrite(text, "C");
                }
                else if (keyboard.IsKeyDown(Keys.D))
                {
                    text = Masswrite(text, "D");
                }
                else if (keyboard.IsKeyDown(Keys.E))
                {
                    text = Masswrite(text, "E");
                }
                else if (keyboard.IsKeyDown(Keys.F))
                {
                    text = Masswrite(text, "F");
                }
                else if (keyboard.IsKeyDown(Keys.G))
                {
                    text = Masswrite(text, "G");
                }
                else if (keyboard.IsKeyDown(Keys.H))
                {
                    text = Masswrite(text, "H");
                }
                else if (keyboard.IsKeyDown(Keys.I))
                {
                    text = Masswrite(text, "I");
                }
                else if (keyboard.IsKeyDown(Keys.J))
                {
                    text = Masswrite(text, "J");
                }
                else if (keyboard.IsKeyDown(Keys.K))
                {
                    text = Masswrite(text, "K");
                }
                else if (keyboard.IsKeyDown(Keys.L))
                {
                    text = Masswrite(text, "L");
                }
                else if (keyboard.IsKeyDown(Keys.M))
                {
                    text = Masswrite(text, "M");
                }
                else if (keyboard.IsKeyDown(Keys.N))
                {
                    text = Masswrite(text, "N");
                }
                else if (keyboard.IsKeyDown(Keys.O))
                {
                    text = Masswrite(text, "O");
                }
                else if (keyboard.IsKeyDown(Keys.P))
                {
                    text = Masswrite(text, "p");
                }
                else if (keyboard.IsKeyDown(Keys.Q))
                {
                    text = Masswrite(text, "Q");
                }
                else if (keyboard.IsKeyDown(Keys.R))
                {
                    text = Masswrite(text, "R");
                }
                else if (keyboard.IsKeyDown(Keys.S))
                {
                    text = Masswrite(text, "S");
                }
                else if (keyboard.IsKeyDown(Keys.T))
                {
                    text = Masswrite(text, "T");
                }
                else if (keyboard.IsKeyDown(Keys.U))
                {
                    text = Masswrite(text, "U");
                }
                else if (keyboard.IsKeyDown(Keys.V))
                {
                    text = Masswrite(text, "V");
                }
                else if (keyboard.IsKeyDown(Keys.W))
                {
                    text = Masswrite(text, "W");
                }
                else if (keyboard.IsKeyDown(Keys.X))
                {
                    text = Masswrite(text, "X");
                }
                else if (keyboard.IsKeyDown(Keys.Y))
                {
                    text = Masswrite(text, "Y");
                }
                else if (keyboard.IsKeyDown(Keys.Z))
                {
                    text = Masswrite(text, "Z");
                }
                else if (keyboard.IsKeyDown(Keys.D8) && oldkeyboard.IsKeyUp(Keys.D8))
                {
                    text = Masswrite(text, "(");
                }
                else if (keyboard.IsKeyDown(Keys.D9) && oldkeyboard.IsKeyUp(Keys.D9))
                {
                    text = Masswrite(text, ")");
                }
            }
            else
            {
                if (keyboard.IsKeyDown(Keys.A) && oldkeyboard.IsKeyUp(Keys.A))
                {
                    text = text + "a";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.B) && oldkeyboard.IsKeyUp(Keys.B))
                {
                    text = text + "b";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.C) && oldkeyboard.IsKeyUp(Keys.C))
                {
                    text = text + "c";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.D) && oldkeyboard.IsKeyUp(Keys.D))
                {
                    text = text + "d";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.E) && oldkeyboard.IsKeyUp(Keys.E))
                {
                    text = text + "e";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.F) && oldkeyboard.IsKeyUp(Keys.F))
                {
                    text = text + "f";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.G) && oldkeyboard.IsKeyUp(Keys.G))
                {
                    text = text + "g";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.H) && oldkeyboard.IsKeyUp(Keys.H))
                {
                    text = text + "h";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.I) && oldkeyboard.IsKeyUp(Keys.I))
                {
                    text = text + "i";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.J) && oldkeyboard.IsKeyUp(Keys.J))
                {
                    text = text + "j";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.K) && oldkeyboard.IsKeyUp(Keys.K))
                {
                    text = text + "k";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.L) && oldkeyboard.IsKeyUp(Keys.L))
                {
                    text = text + "l";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.M) && oldkeyboard.IsKeyUp(Keys.M))
                {
                    text = text + "m";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.N) && oldkeyboard.IsKeyUp(Keys.N))
                {
                    text = text + "n";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.O) && oldkeyboard.IsKeyUp(Keys.O))
                {
                    text = text + "o";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.P) && oldkeyboard.IsKeyUp(Keys.P))
                {
                    text = text + "p";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.Q) && oldkeyboard.IsKeyUp(Keys.Q))
                {
                    text = text + "q";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.R) && oldkeyboard.IsKeyUp(Keys.R))
                {
                    text = text + "r";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.S) && oldkeyboard.IsKeyUp(Keys.S))
                {
                    text = text + "s";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.T) && oldkeyboard.IsKeyUp(Keys.T))
                {
                    text = text + "t";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.U) && oldkeyboard.IsKeyUp(Keys.U))
                {
                    text = text + "u";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.V) && oldkeyboard.IsKeyUp(Keys.V))
                {
                    text = text + "v";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.W) && oldkeyboard.IsKeyUp(Keys.W))
                {
                    text = text + "w";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.X) && oldkeyboard.IsKeyUp(Keys.X))
                {
                    text = text + "x";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.Y) && oldkeyboard.IsKeyUp(Keys.Y))
                {
                    text = text + "y";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.Z) && oldkeyboard.IsKeyUp(Keys.Z))
                {
                    text = text + "z";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.D1) && oldkeyboard.IsKeyUp(Keys.D1))
                {
                    text = text + "1";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.D2) && oldkeyboard.IsKeyUp(Keys.D2))
                {
                    text = text + "2";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.D3) && oldkeyboard.IsKeyUp(Keys.D3))
                {
                    text = text + "3";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.D4) && oldkeyboard.IsKeyUp(Keys.D4))
                {
                    text = text + "4";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.D5) && oldkeyboard.IsKeyUp(Keys.D5))
                {
                    text = text + "5";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.D6) && oldkeyboard.IsKeyUp(Keys.D6))
                {
                    text = text + "6";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.D7) && oldkeyboard.IsKeyUp(Keys.D7))
                {
                    text = text + "7";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.D8) && oldkeyboard.IsKeyUp(Keys.D8))
                {
                    text = text + "8";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.D9) && oldkeyboard.IsKeyUp(Keys.D9))
                {
                    text = text + "9";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.D0) && oldkeyboard.IsKeyUp(Keys.D0))
                {
                    text = text + "0";
                    textCountdown = 0;
                }
                else if (keyboard.IsKeyDown(Keys.A))
                {
                    text = Masswrite(text, "a");
                }
                else if (keyboard.IsKeyDown(Keys.B))
                {
                    text = Masswrite(text, "b");
                }
                else if (keyboard.IsKeyDown(Keys.C))
                {
                    text = Masswrite(text, "c");
                }
                else if (keyboard.IsKeyDown(Keys.D))
                {
                    text = Masswrite(text, "d");
                }
                else if (keyboard.IsKeyDown(Keys.E))
                {
                    text = Masswrite(text, "e");
                }
                else if (keyboard.IsKeyDown(Keys.F))
                {
                    text = Masswrite(text, "f");
                }
                else if (keyboard.IsKeyDown(Keys.G))
                {
                    text = Masswrite(text, "g");
                }
                else if (keyboard.IsKeyDown(Keys.H))
                {
                    text = Masswrite(text, "h");
                }
                else if (keyboard.IsKeyDown(Keys.I))
                {
                    text = Masswrite(text, "i");
                }
                else if (keyboard.IsKeyDown(Keys.J))
                {
                    text = Masswrite(text, "j");
                }
                else if (keyboard.IsKeyDown(Keys.K))
                {
                    text = Masswrite(text, "k");
                }
                else if (keyboard.IsKeyDown(Keys.L))
                {
                    text = Masswrite(text, "l");
                }
                else if (keyboard.IsKeyDown(Keys.M))
                {
                    text = Masswrite(text, "m");
                }
                else if (keyboard.IsKeyDown(Keys.N))
                {
                    text = Masswrite(text, "n");
                }
                else if (keyboard.IsKeyDown(Keys.O))
                {
                    text = Masswrite(text, "o");
                }
                else if (keyboard.IsKeyDown(Keys.P))
                {
                    text = Masswrite(text, "p");
                }
                else if (keyboard.IsKeyDown(Keys.Q))
                {
                    text = Masswrite(text, "q");
                }
                else if (keyboard.IsKeyDown(Keys.R))
                {
                    text = Masswrite(text, "r");
                }
                else if (keyboard.IsKeyDown(Keys.S))
                {
                    text = Masswrite(text, "s");
                }
                else if (keyboard.IsKeyDown(Keys.T))
                {
                    text = Masswrite(text, "t");
                }
                else if (keyboard.IsKeyDown(Keys.U))
                {
                    text = Masswrite(text, "u");
                }
                else if (keyboard.IsKeyDown(Keys.V))
                {
                    text = Masswrite(text, "v");
                }
                else if (keyboard.IsKeyDown(Keys.W))
                {
                    text = Masswrite(text, "w");
                }
                else if (keyboard.IsKeyDown(Keys.X))
                {
                    text = Masswrite(text, "x");
                }
                else if (keyboard.IsKeyDown(Keys.Y))
                {
                    text = Masswrite(text, "y");
                }
                else if (keyboard.IsKeyDown(Keys.Z))
                {
                    text = Masswrite(text, "z");
                }
                else if (keyboard.IsKeyDown(Keys.D1))
                {
                    text = Masswrite(text, "1");
                }
                else if (keyboard.IsKeyDown(Keys.D2))
                {
                    text = Masswrite(text, "2");
                }
                else if (keyboard.IsKeyDown(Keys.D3))
                {
                    text = Masswrite(text, "3");
                }
                else if (keyboard.IsKeyDown(Keys.D4))
                {
                    text = Masswrite(text, "4");
                }
                else if (keyboard.IsKeyDown(Keys.D5))
                {
                    text = Masswrite(text, "5");
                }
                else if (keyboard.IsKeyDown(Keys.D6))
                {
                    text = Masswrite(text, "6");
                }
                else if (keyboard.IsKeyDown(Keys.D7))
                {
                    text = Masswrite(text, "7");
                }
                else if (keyboard.IsKeyDown(Keys.D8))
                {
                    text = Masswrite(text, "8");
                }
                else if (keyboard.IsKeyDown(Keys.D9))
                {
                    text = Masswrite(text, "9");
                }
                else if (keyboard.IsKeyDown(Keys.D0))
                {
                    text = Masswrite(text, "0");
                }
            }
            int size = (int)(font.MeasureString(text).X * textscale);
            line.Update(x + size);
        }
        public string GetText()
        {
            return text;
        }
        private string Masswrite(string input, string letter)
        {
            if (textCountdown > 20)
            {
                textCountdown2++;
                if (textCountdown2 > 2)
                {
                    input = input + letter;
                    textCountdown2 = 0;
                }
            }
            else
            {
                textCountdown++;
            }
            return input;
        }
        public void Draw(SpriteBatch spriteBatch, string extra)
        {
            int offset = (int)(font.MeasureString(extra).X * textscale);
            spriteBatch.DrawString(font, extra + text, new Vector2(x, y), Color.Black,
            0, new Vector2(0, 0), textscale, SpriteEffects.None, 1f);
            line.Draw(spriteBatch, offset);
        }
    }
}
