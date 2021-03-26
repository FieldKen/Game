using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Rock : MapElement, IDestructableByMonster
    {
        public Rock(char drawChar) : base(drawChar)
        {
            DrawChar = drawChar;
        }
    }
}
