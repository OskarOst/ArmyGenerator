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
    class Doot:AllFather
    {
        private int countdown;
        private bool end;
        SoundEffect dootSound;
        public Doot(SoundEffect doot, Texture2D dootTexture, int x, int y):base(dootTexture, 1, 1, x, y)
        {
            dootSound = doot;
            dootSound.Play();
            end = false;
            countdown = 30;
        }
        public bool End()
        {
            return end;
        }
        public override void Update(MouseState mouseState, MouseState oldMouseState)
        {
            base.Update(mouseState, oldMouseState);
            countdown--;
            if (countdown == 0)
            {
                end = true;
            }
        }
    }
}
