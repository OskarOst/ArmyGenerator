using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArmyGenerator
{
    class SwitchArmyButton : AllFather
    {
        public SwitchArmyButton(Texture2D texture, int frame, int x, int y, float scaledWidth, float scaledHeigth) : base(texture, 1, 2, x, y)
        {
            currentFrame = frame;
            mainRec.Width = (int)(mainRec.Width * scaledWidth);
            mainRec.Height = (int)(mainRec.Height * scaledHeigth);
        }
        public void Rescale(float scaledHeigth, float scaledWidth, int x, int y)
        {
            mainRec = new Rectangle(x,y, (int)(texture.Width / 2 * scaledWidth), (int)(texture.Height * scaledHeigth));
        }
    }
}
