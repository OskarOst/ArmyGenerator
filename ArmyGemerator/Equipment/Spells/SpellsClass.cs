using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyGenerator
{
    [Serializable]
    class SpellsClass
    {
        private string text;
        private string name;
        public void SetText(string name, string text)
        {
            this.name = name;
            this.text = text;
        }
        public string GetName()
        {
            return name;
        }
        public string GetText()
        {
            return text;
        }
    }
}
