using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class MapElement
    {
        private char drawChar;

        public char DrawChar
        {
            get { return drawChar; }
            set { drawChar = value; }
        }

        public Point Location { get; set; }

        public MapElement(char drawChar)
        {
            DrawChar = drawChar;
        }

        public MapElement()
        {
        }

        public void Draw()
        {
            Console.Write($"[{drawChar}]");
        }

    }
}
