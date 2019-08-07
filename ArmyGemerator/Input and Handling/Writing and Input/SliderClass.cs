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
    class SliderClass
    {
        Marker marker;
        List<UpDownButtons> upDownButtons;
        int sliderPositions;
        int sliderPosition;
        int drawinglenght;
        int sliderYPos;
        int sliderHeight;
        int ypos;
        int drawFrom;
        int moveNumber;
        Rectangle drawRec;
        int speed;
        public SliderClass( Texture2D mark, Texture2D upDown, int sliderHeight, int drawingLenght, int ypos, int x1, int y1, int y2, int xslider, int moveNumber)
        {
            drawFrom = 0;
            this.moveNumber = moveNumber;
            this.ypos = ypos; 
            this.sliderHeight = sliderHeight - mark.Height;
            this.drawinglenght = drawingLenght;
            sliderPosition = 0;
            sliderPositions = 0; 
            marker = new Marker(mark, 1, 1, xslider, ypos);
            upDownButtons = new List<UpDownButtons>();
            upDownButtons.Add(new UpDownButtons(upDown, 1, 2, x1, y1, 0));
            upDownButtons.Add(new UpDownButtons(upDown, 1, 2, x1, y2, 1));
            drawRec = new Rectangle(upDownButtons[0].mainRec.X+ upDownButtons[0].width/2 -1, y1 + upDownButtons[0].height, 2, sliderHeight);
        }
        public void Update(MouseState mousestate, MouseState oldmousestate, int lenghtOfInput)
        {
            for (int i = 0; i < upDownButtons.Count; i++)
            {
                upDownButtons[i].Update(mousestate, oldmousestate);
            }
            sliderPositions = lenghtOfInput - drawinglenght;
            if (sliderPositions < 0)
            {
                sliderPositions = 0;
            }
            if(sliderPosition > sliderPositions)
            {
                sliderPosition = sliderPositions;
            }
            if(sliderPositions > 0)
            sliderYPos = (sliderHeight / sliderPositions) * sliderPosition;
            else
            {
                sliderYPos = 0; 
            }
            marker.pos(ypos + sliderYPos);
        }
        public int Negative()
        {
            return 0 - (sliderPosition * 20);
        }
        public bool ChangeButtons(MouseState mouseState, MouseState oldmouseState)
        {
            if (upDownButtons[0].pressed || upDownButtons[1].pressed || mouseState.ScrollWheelValue > oldmouseState.ScrollWheelValue || mouseState.ScrollWheelValue < oldmouseState.ScrollWheelValue)
            {
                return true;
            }
            return false;
        }
        public int GetMoveDirection(MouseState mouseState, MouseState oldmouseState)
        {
            if((upDownButtons[0].pressed  || mouseState.ScrollWheelValue > oldmouseState.ScrollWheelValue) && sliderPosition > 0)
            {
                Up();
                return moveNumber;
            }
            else if ((upDownButtons[1].pressed || mouseState.ScrollWheelValue < oldmouseState.ScrollWheelValue) && sliderPosition != sliderPositions)
            {
                Down();
                return 0- moveNumber;
            }
            return 0;
        }
        public int GetSliderPos()
        {
            return sliderPosition;
        }
        public void Up()
        {
            drawFrom--;
            sliderPosition--;
            marker.Up(0);
        }
        public void Down()
        {
            drawFrom++;
            sliderPosition++;
            marker.Down(0);
        }
        public int DrawFrom()
        {
            return drawFrom;
        }
        public int GetDrawingLenght()
        {
            return drawinglenght;
        }
        public void Resize(int x, int y, int y2)
        {
            ypos = y;
            drawFrom = 0;
            sliderPosition = 0;
            upDownButtons[0].Repos(x - upDownButtons[0].width / 2 - 2, y - upDownButtons[0].height);
            upDownButtons[1].Repos(x - upDownButtons[0].width / 2 - 2, y2);
            marker.Repos(x - (marker.mainRec.Width / 2) - 2, y);
        }
        public void Resize(int x, int y, int y2, int slotHeight)
        {
            ypos = y;
            drawFrom = 0;
            sliderPosition = 0;
            upDownButtons[0].Repos(x - upDownButtons[0].width / 2 - 2, y - upDownButtons[0].height);
            upDownButtons[1].Repos(x - upDownButtons[0].width / 2 - 2, y2);
            marker.Repos(x - (marker.mainRec.Width / 2) - 2, y);
            if (drawRec != null)
            {
                drawinglenght = (y2 - (y - upDownButtons[0].height)) / slotHeight;
                drawRec = new Rectangle(upDownButtons[0].mainRec.X + upDownButtons[0].width / 2 - 1, y + marker.mainRec.Height, 2, y2- y- marker.mainRec.Height);
                sliderHeight = y2 - y - marker.mainRec.Height;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            marker.Draw(spriteBatch);
            for (int i = 0; i < upDownButtons.Count; i++)
            {
                upDownButtons[i].Draw(spriteBatch);
            }
        }
        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Draw(marker.texture, drawRec, Color.Black);
            Draw(spriteBatch);
        }
    }
}
