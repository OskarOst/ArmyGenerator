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
    public enum State
    {
        On,
        Off
    }
    class MarkButton : AllFather
    {
        public State state = State.Off;
        private string text;
        private SoundEffect sound;
        private float volume;
        SoundEffectInstance instance;
        public MarkButton(Texture2D texture, int rows, int columns, int xPos, int yPos, string text, SoundEffect sound) : base(texture, 3, columns, xPos, yPos)
        {
            this.text = text;
            this.sound = sound;
            volume = 1.0f;
        }
        public MarkButton(Texture2D texture, int rows, int columns, int xPos, int yPos, string text, SoundEffect sound, float volume) : base(texture, 3, columns, xPos, yPos)
        {
            this.text = text;
            this.sound = sound;
            this.volume = volume;
        }
        //
        public bool PressedState()
        {
            if (state == State.On)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ChangeText(string text)
        {
            this.text = text;
        }
        public void ChangeState()
        {
            if (state == State.Off)
            {
                turnOn();
            }
            else
            {
                Clear();
            }
        }
        public void turnOn()
        {
            state = State.On;
            currentFrame = 1;
        }
        public void Clear()
        {
            state = State.Off;
            currentFrame = 0;
        }
        public void Sound()
        {
            if (sound != null)
                sound.Play(volume, 0.0f, 0.0f);
        }
        public void tempTest()
        {
            if (state == State.On)
            {
                pressed = true;
            }
        }
        public string Text()
        {
            return text;
        }
        public override void Update(MouseState mouseState, MouseState oldMouseState)
        {
            base.Update(mouseState, oldMouseState);
        }
        public void Reposition(int input)
        {
            mainRec.Y = input;
        }
        public void Reposition(int y, int x)
        {
            mainRec.Y = y;
            mainRec.X = x;
        }
        public bool IsTurnedOn()
        {
            if (state == State.On)
            {
                return true;
            }
            return false;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        public void Draw(SpriteBatch spriteBatch, int pos)
        {
            int row = (int)((float)currentFrame / (float)columns);
            int column = currentFrame % columns;
            Rectangle tempRectangle = mainRec;
            tempRectangle.Y = pos;
            Rectangle sourceRec = new Rectangle(mainRec.Width * column, mainRec.Height * row, mainRec.Width, mainRec.Height);
            spriteBatch.Draw(texture, tempRectangle, sourceRec, Color.White);
        }
    }
}
