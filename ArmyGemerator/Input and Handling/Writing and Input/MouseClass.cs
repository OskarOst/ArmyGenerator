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
    class MouseClass : AllFather
    {
        public MouseClass(Texture2D texture, int rows, int columns) : base(texture, rows, columns, 0, 0)
        {

        }
        public void Update()
        {
            MouseState mouse = Mouse.GetState();
            mainRec.X = mouse.X;
            mainRec.Y = mouse.Y;
        }
        public void Reposision()
        {

        }
    }
}
