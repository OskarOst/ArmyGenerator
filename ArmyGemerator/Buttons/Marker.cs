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
    class Marker :AllFather
    {
        public Marker(Texture2D texture, int rows, int columns, int xPos, int yPos) : base(texture, rows, columns, xPos, yPos)
        {

        }
        public void pos(int input)
        {
            mainRec.Y = input;
        }
        public void Down(int speed)
        {
            mainRec.Y += speed;
        }
        public void Up(int speed)
        {
            mainRec.Y -= speed;
        }
    }
}
