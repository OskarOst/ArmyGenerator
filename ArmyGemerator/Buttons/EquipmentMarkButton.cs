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
    class EquipmentMarkButton : MarkButton
    {
        private Equipment equipment;
        private bool canBeShown;
        private bool giveItem;
        public EquipmentMarkButton(Equipment equipment, Texture2D texture, int rows, int columns, int xPos, int yPos, string text, SoundEffect sound) : base(texture, rows, columns, xPos, yPos, text, sound)
        {
            giveItem = false;
            canBeShown = true;
            this.equipment = equipment;
        }
        public EquipmentMarkButton(Equipment equipment, Texture2D texture, int rows, int columns, int xPos, int yPos, string text, SoundEffect sound, float volume) : base(texture, rows, columns, xPos, yPos, text, sound, volume)
        {
            giveItem = false;
            canBeShown = true;
            this.equipment = equipment;
        }
        public bool Show()
        {
            return canBeShown;
        }
        public void ChangeType(Equipment equipment, string text)
        {
            this.equipment = equipment;
            ChangeText(text);
        }
        public bool CountdownOver(MouseState mouse)
        {
            giveItem = false;
            Rectangle temp = new Rectangle();
            temp.Height = 1;
            temp.Width = 1;
            temp.X = mouse.X;
            temp.Y = mouse.Y;
            if (temp.Intersects(mainRec))
            {
                giveItem = true;
            }
            return giveItem;
        }
        public void TurnOffShow()
        {
            currentFrame = 2;
        }
        public bool IsTurnedOff()
        {
            if (currentFrame == 2)
            {
                return true;
            }
            return false;
        }
        public void TurnOnShow()
        {
            Clear();
        }
        public string Text(int i)
        {
            string text = equipment.GetName() + " " + 20 * i + " Pts"; 
            return text;
        }
        public bool MouseIntersect(Rectangle rectangle)
        {
            if (rectangle.Intersects(mainRec))
            {
                return true;
            }
            return false;
        }
        public Equipment GetEquipment()
        {
            return equipment;
        }
    }
}
